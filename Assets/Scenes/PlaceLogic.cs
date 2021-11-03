using System.Collections.Generic;
using UnityEngine;

public class PlaceLogic : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> MegaCubes;

    void Start()
    {
        var megacube = Instantiate(MegaCubes[Cookie.room.IndexCube], transform);
        //megacube.SendMessage("IntPlayer", player);
    }

    //public override void OnServerAddPlayer(NetworkConnection conn)
    //{
    //    // add player at correct spawn position
    //    //Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
    //    GameObject player = Instantiate(playerPrefab);
        
    //    inputmanager.cc = player.GetComponent<vThirdPersonController>();
    //    inputmanager.cc.animator = player.GetComponent<Animator>();
    //    inputmanager.cc._rigidbody = player.GetComponent<Rigidbody>();
    //    inputmanager.cc._capsuleCollider = player.GetComponent<CapsuleCollider>();
    //    inputmanager.cc.colliderCenter = player.GetComponent<CapsuleCollider>().center;
    //    inputmanager.cc.colliderRadius = player.GetComponent<CapsuleCollider>().radius;
    //    inputmanager.cc.colliderHeight = player.GetComponent<CapsuleCollider>().height;

    //    inputmanager.gameObject.SetActive(true);
    //    player.SetActive(true);
    //    NetworkServer.AddPlayerForConnection(conn, player);

    //    // spawn ball if two players
    //    //if (numPlayers == 2)
    //    //{
    //    //    ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
    //    //    NetworkServer.Spawn(ball);
    //    //}
    //}

    //public override void OnServerDisconnect(NetworkConnection conn)
    //{
    //    // destroy ball
    //    //if (ball != null)
    //    //    NetworkServer.Destroy(ball);

    //    // call base functionality (actually destroys the player)
    //    base.OnServerDisconnect(conn);
    //}
}
