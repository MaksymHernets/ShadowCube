using ShadowCube.DTO;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube.Config
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/newItem", order = 1)]
    public class ItemsConfig : ScriptableObject
    {
		[SerializeField] private List<ItemDTO> lists;

		public List<ItemDTO> GetItems()
		{
			return lists;
		}

		public ItemDTO GetItem(int index)
		{
			if (index < lists.Count)
			{
				return lists[index];
			}
			else
			{
				return lists[0];
			}
		}
	}
}



