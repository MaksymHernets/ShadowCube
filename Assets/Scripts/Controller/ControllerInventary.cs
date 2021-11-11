using ShadowCube.DTO;
using ShadowCube.Models;
using ShadowCube.UI;
using System.Collections;
using UnityEngine;

namespace ShadowCube.Controller
{
	public class ControllerInventary : IController
	{
		[SerializeField] private ItemUI prefabItemUI;
		[SerializeField] private BoxHolderUI[] buttons;

		private ItemUI currentgameObjectItemUI;
		private ItemDTO currentItemDTO;
		private Coroutine coroutineUpdatePositionItem;

		private ItemUI[] gamemObjectItemUIs;

		private ModelInventary _model;

		public override void Init(IModel model)
		{
			_model = model as ModelInventary;

			gameObject.SetActive(true);

			for (int i = 0; i < _model.items.Length; ++i)
			{
				if ( _model.items[i] != null )
				{
					gamemObjectItemUIs[i].image.sprite = _model.items[i].sprite;
					gamemObjectItemUIs[i].gameObject.SetActive(true);
				}
			}
			
		}

		private void Awake()
		{
			Cursor.visible = true;
			for (int i = 0; i < buttons.Length; ++i)
			{
				buttons[i].index = i;
				buttons[i].Event_Click += Handler_ButtonClick;
			}

			gamemObjectItemUIs = new ItemUI[24];

			for (int i = 0; i < _model.items.Length; ++i)
			{
				gamemObjectItemUIs[i] = GameObject.Instantiate(prefabItemUI, buttons[i].transform);
			}
		}

		private void Handler_ButtonClick(int index)
		{
			if (gamemObjectItemUIs[index] != null && currentgameObjectItemUI != null)
			{
				var temp1 = gamemObjectItemUIs[index];
				var temp2 = _model.items[index];

				gamemObjectItemUIs[index] = currentgameObjectItemUI;
				_model.items[index] = currentItemDTO;
				currentgameObjectItemUI.transform.parent = buttons[index].transform;
				currentgameObjectItemUI.transform.localPosition = new Vector3();

				currentgameObjectItemUI = temp1;
				currentItemDTO = temp2;
			}
			else if ( gamemObjectItemUIs[index] != null && currentgameObjectItemUI == null )
			{
				GetupItem(index);
				gamemObjectItemUIs[index] = null;
				_model.items[index] = null;
				coroutineUpdatePositionItem = StartCoroutine(UpdatePositionItem());
			}
			else if ( gamemObjectItemUIs[index] == null && currentgameObjectItemUI != null )
			{
				StopCoroutine(coroutineUpdatePositionItem);
				PutItem(index);
				currentgameObjectItemUI = null;
			}
		}

		private void GetupItem(int index)
		{
			currentgameObjectItemUI = gamemObjectItemUIs[index];
			currentItemDTO = _model.items[index];
		}	

		private void PutItem(int index)
		{
			gamemObjectItemUIs[index] = currentgameObjectItemUI;
			_model.items[index] = currentItemDTO;
			currentgameObjectItemUI.transform.parent = buttons[index].transform;
			currentgameObjectItemUI.transform.localPosition = new Vector3();
		}

		private IEnumerator UpdatePositionItem()
		{
			while (true)
			{
				currentgameObjectItemUI.transform.position = Input.mousePosition;
				yield return new WaitForEndOfFrame();
			}
		}
	}

	public class CellItem
	{
		public TypeItem typeItem;
		public ItemUI itemUI;

		public bool IsEmpty()
		{
			return true;
		}
	}
}