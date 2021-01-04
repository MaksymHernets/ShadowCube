using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLobyHost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.playerName = Cookie.mainPlayer.name;
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.gameVersion = "0.1.0";
        PhotonNetwork.ConnectUsingSettings("0.1.0");

        PhotonNetwork.CreateRoom(GenerateCode());
    }


    private string GenerateCode()
    {
        return Random.Range(100000, 999999).ToString();
    }

    public void InputField_EditEnd(string code)
    {
        PhotonNetwork.JoinRandomRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
