using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class tile : MonoBehaviour
{
	public List<GameObject> colors;
	public Bounds bounds;

	private int _color;

	[ShowInInspector, ReadOnly]
	public Vector3Int where { get; set; }

	[ShowInInspector, ReadOnly]
	public int color
	{
		get => _color;
		set
		{
			_color = colors.invalid(value) ? colors.randomIndex() : value;
			colors.setActiveByIndex(_color);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(transform.position + bounds.center, bounds.size);
	}
}
