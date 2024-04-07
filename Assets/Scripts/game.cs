using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
	public tileMaker tileMaker;
	public player player;

	public Text scoreText;

	private LinkedListNode<tile> _current;
	private LinkedListNode<tile> _previous;

	private int _score;

	public tile curr => _current?.Value;
	public tile next => _current.Next?.Value;

	public int score
	{
		get => _score;
		set
		{
			scoreText.text = value.ToString();
			_score = value;
		}
	}

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
		reset();
	}

	public void reset()
	{
		_current = tileMaker.initialize();
		_previous = null;
	}

	public void step()
	{
		_previous = _current;
		_current = _current.Next;

		score++;
		
		onStep();
	}

	public void onStep()
	{
		tileMaker.make();
		player.onStep(_previous, _current, 0.3f);
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
