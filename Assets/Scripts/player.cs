using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using Freya;
using UnityEngine;

public class player : MonoBehaviour
{
	public AnimancerComponent animancer;
	public ClipTransition idle;
	public ClipTransition run;

	private ((Vector3 prev, Vector3 next) position, (float prev, float next) time) _stepper; 

	public LinkedListNode<tile> coord { get; set; }
	public tile where => coord?.Value;

	private void Start()
	{
		animancer.Play(idle);
	}

	private void Update()
	{
		if (_stepper.time.prev == _stepper.time.next)
			return;
		
		var t = Time.time.InverseLerpClamped(_stepper.time.prev, _stepper.time.next);
		transform.position = _stepper.position.prev.lerp(_stepper.position.next, t.Smooth01());

		if (t >= 1)
			onArrived();
	}

	public void onStep(LinkedListNode<tile> prev, LinkedListNode<tile> curr, float duration)
	{
		_stepper.position = (prev.Value.transform.position, curr.Value.transform.position);
		_stepper.time = (Time.time, Time.time + duration);
		
		coord = curr;

		onDepart();
	}

	public void onDepart()
	{
		animancer.Play(run);
	}

	public void onArrived()
	{
		animancer.Play(idle);

		_stepper.time = default;
	}
}
