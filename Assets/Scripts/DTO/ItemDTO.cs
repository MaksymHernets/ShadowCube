using System;
using UnityEngine;

namespace ShadowCube.DTO
{
    [System.Serializable]
    public class ItemDTO : ICloneable
    {
        [SerializeField] public int ID;
        [SerializeField] public string name;
        [SerializeField] public string description;
        [SerializeField] public TypeItem typeItem;
        [SerializeField] public GameObject gameObject;
        [SerializeField] public Sprite sprite;
        
        public object Clone()
		{
            return new ItemDTO();
		}
	}
    public enum TypeItem
    {
        None = 0,
        Head = 1,
        Body = 2,
        Legs = 3,
        Shoes = 4,
        Gun = 5
    }

}
