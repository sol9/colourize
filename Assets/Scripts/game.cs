using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
	public tileMaker tileMaker;
	public player player;

	private LinkedListNode<tile> _current;

	public tile curr => _current?.Value;
	public tile next => _current.Next?.Value;

	private void OnValidate()
	{
		if (!tileMaker)
			tileMaker = GetComponent<tileMaker>();

		if (!player)
			player = FindObjectOfType<player>();
	}

	private void Start()
	{
		initialize();
	}

	public void initialize()
	{
		_current = tileMaker.initialize();
	}

	public void reset()
	{
	}

	public void step()
	{
		_current = _current.Next;

		onStep();
	}

	public void onStep()
	{
	}

	public void onButtonEvent(int index)
	{
		if (curr == null || next == null)
			return;

		if (next.color != index)
			return;

		step();
	}
}
