using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLogic : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> MegaCubes;

    void Start()
    {
        var megacube = Instantiate(MegaCubes[Cookie.room.IndexCube], transform);
        megacube.SendMessage("IntPlayer", (object)player);
    }
}
