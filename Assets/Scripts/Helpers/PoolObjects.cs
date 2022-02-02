using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube.Helpers
{
	public class PoolObjects<T> : MonoBehaviour where T : MonoBehaviour
	{
		private List<MonoBehaviour> lists;
		private T _prefab;

		public PoolObjects(T prefab, int defaultSize = 20)
		{
			lists = new List<MonoBehaviour>();
			_prefab = prefab;

			for (int i = 0; i < defaultSize; ++i)
			{
				var newObject = GameObject.Instantiate(_prefab);
				newObject.gameObject.SetActive(false);
				lists.Add(newObject);
			}
		}

		public T Get()
		{
			for (int i = 0; i < lists.Count; ++i)
			{
				if (lists[i].gameObject.activeSelf == false)
				{
					lists[i].gameObject.SetActive(true);
					return (T)lists[i];
				}
			}
			var newObject = GameObject.Instantiate(_prefab);
			lists.Add(newObject);
			return (T)newObject;
		}
	}
}