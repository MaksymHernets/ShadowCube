using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ShadowCube
{
    public class SmartButtonUI : Button
    {
        public UnityAction<Button> OnClick;
        [SerializeField] public Text Name;

		protected override void Start()
		{
			this.onClick.AddListener(Event_OnClick);
		}

		public void Event_OnClick()
		{
			OnClick.Invoke(this);
		}
		
	}
}
