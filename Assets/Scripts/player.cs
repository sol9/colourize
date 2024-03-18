using System.Collections;
using System.Collections.Generic;
using Animancer;
using UnityEngine;

public class player : MonoBehaviour
{
	public AnimancerComponent animancer;
	public ClipTransition idle;
	public ClipTransition run;

	public LinkedListNode<tile> coord { get; set; }
	public tile where => coord?.Value;

	private void Start()
	{
		animancer.Play(idle);
	}
}
