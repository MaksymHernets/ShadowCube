using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
	//public GameObject item;

	public List<Button> buttons;

	public List<Image> images;

	public List<Sprite> icons;

	private List<Item> lists;

	private void Start()
	{
		

	}

	public void Show()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}

	public void AddItem(object itemm)
	{
		var item = (Item)itemm;
		images[item.id].sprite = icons[item.IdImage];
		images[item.id].color = Color.white;
	}

	public void DeleteItem(object itemm)
	{
		var id = (int)itemm;
		images[id].sprite = null;
	}
}

public class Item
{
	public int id;

	public int IdImage;

	public string name;
}
