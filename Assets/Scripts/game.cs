using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
	public tileMaker tileMaker;
	public player player;

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
		tileMaker.initialize();
	}
}
