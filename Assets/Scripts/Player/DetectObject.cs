using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectObject : MonoBehaviour
{
	public UnityAction<GameObject> EveneCollision;
	public UnityAction<GameObject> EveneCollisionExit;

	[SerializeField] private BoxCollider boxCollider;
	[SerializeField] private List<string> nameTags;

	private void OnTriggerEnter(Collider collision)
	{
		foreach (string name in nameTags)
		{
			if ( collision.gameObject.CompareTag(name) )
			{
				EveneCollision?.Invoke(collision.gameObject);
			}
		}
	}

	private void OnTriggerExit(Collider collision)
	{
		foreach (string name in nameTags)
		{
			if (collision.gameObject.CompareTag(name))
			{
				EveneCollisionExit?.Invoke(collision.gameObject);
			}
		}
	}
}
