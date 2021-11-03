using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects<T> : MonoBehaviour where T : MonoBehaviour
{
	private List<GameObject> lists;
	private T _prefab;

    public PoolObjects(T prefab, int defaultSize = 20)
	{
		lists = new List<GameObject>();
		_prefab = prefab;

		for (int i = 0; i < defaultSize; ++i)
		{
			var newObject = GameObject.Instantiate(_prefab);
			newObject.gameObject.SetActive(false);
			lists.Add(newObject.gameObject);
		}
	}

	public GameObject Get()
	{
		for (int i = 0; i < lists.Count; ++i)
		{
			if ( lists[i].activeSelf == false)
			{
				return lists[i];
			}
		}
		var newObject = GameObject.Instantiate(_prefab).gameObject;
		lists.Add(newObject);
		return newObject;
	}
}
