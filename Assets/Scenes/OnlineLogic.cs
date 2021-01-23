using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using Mirror.Discovery;

public class OnlineLogic : MonoBehaviour
{
	public GameObject MainMenu;

	public ItemHost prefabItem;
	public Transform contect;

	public Button buttonIsLocal;
	public Button buttonRefresh;

	public Button buttonCubeOne;
	public Button buttonHyperCube;
	public Button buttonCubeZero;
	public Button buttonSketchCube;

	//public NetworkDiscovery networkDiscovery;
	//readonly Dictionary<long, ServerResponse> discoveredServers = new Dictionary<long, ServerResponse>();

	//private void Awake()
	//{
	//	//UnityEditor.Events.UnityEventTools.AddPersistentListener(networkDiscovery.OnServerFound, OnDiscoveredServer);
	//	//UnityEditor.Undo.RecordObjects(new Object[] { this, networkDiscovery }, "Set NetworkDiscovery");
	//}


	//public void OnDiscoveredServer(ServerResponse info)
	//{
	//	// Note that you can check the versioning to decide if you can connect to the server or not using this method
	//	discoveredServers[info.serverId] = info;

	//	prefabItem.player.text = info.serverId.ToString();
	//	var neww = Instantiate(prefabItem, contect);
	//	neww.gameObject.SetActive(true);
	//	neww.transform.localPosition += new Vector3(0, 1f, 0);
	//}

	public void ButtonIsLocal_Click()
	{

	}

	public void ButtonRefresh_Click()
	{

	}

	public void InputFieldIp_EndEdit(string ip)
	{

	}

	public void ButtonBack_Click()
	{
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
