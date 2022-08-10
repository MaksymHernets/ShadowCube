using Generic;
using ShadowCube;
using System;
using UnityEngine;

namespace ShadowCube.UI.Panels
{
	[CreateAssetMenu(fileName = "OptionPanelConfig", menuName = "Configs/CreateOptionPanelConfig", order = 1)]
	public class OptionPanelConfig : ScriptableObject
	{
		public Panels[] platforms;

		public Panels GetPanels(GenericRuntimePlatform genericRuntimePlatform)
		{
			foreach (Panels platform in platforms)
			{
				if (platform.RuntimePlatform == genericRuntimePlatform)
				{
					return platform;
				}
			}
			new Exception("Dont have panels for genericRuntimePlatform -> " + genericRuntimePlatform.ToString());
			return null;
		}
	}

	[Serializable]
	public class Panels
	{
		public GenericRuntimePlatform RuntimePlatform;
		public OptionPanel[] prefabs;
	}
}

