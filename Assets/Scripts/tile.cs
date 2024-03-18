using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class tile : MonoBehaviour
{
	public Renderer renderer;
	public Bounds bounds;

	public int index;

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireCube(transform.position + bounds.center, bounds.size);
	}
}
