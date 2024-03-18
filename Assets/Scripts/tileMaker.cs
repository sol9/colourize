using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class tileMaker : MonoBehaviour
{
	public Transform parent;
	public tile tilePrefab;
	public List<Material> colors;

	private LinkedList<tile> _tiles;

	private void OnValidate()
	{
		if (!parent)
			parent = transform;
	}

	public bool initialize()
	{
		return make(15);
	}

	public bool make(int count = 1)
	{
		if (!tilePrefab)
			return false;

		_tiles ??= new();

		for (var i = 0; i < count; ++i)
		{
			var t = _makeTile();
			if (!t)
				continue;

			var last = _tiles.Last;
			if (last != null)
			{
				var position = last.Value.transform.localPosition;
				var offset = last.Value.bounds.max + t.bounds.max;
				t.transform.localPosition = position + offset.scale(Vector3.forward);
			}

			_tiles.AddLast(t);
		}

		return true;
	}

	private tile _makeTile(int index = -1)
	{
		if (colors.invalid())
			return default;

		if (colors.invalid(index))
			index = helper.randomIndex(colors);

		var t = Instantiate(tilePrefab, parent);
		t.renderer.material = colors[index];
		t.index = index;

		return t;
	}
}
