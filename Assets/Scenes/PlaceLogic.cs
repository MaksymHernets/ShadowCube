using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLogic : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        GameObject prefabcube;
        if (Cookie.room.IndexCube == 0) { prefabcube = Resources.Load<GameObject>("Prefabs/MegaCubeOne"); }
        else if (Cookie.room.IndexCube == 1) { prefabcube = Resources.Load<GameObject>("Prefabs/MegaCubeHyper"); }
        else if (Cookie.room.IndexCube == 2) { prefabcube = Resources.Load<GameObject>("Prefabs/MegaCubeZero"); }
        else if (Cookie.room.IndexCube == 3) { prefabcube = Resources.Load<GameObject>("Prefabs/MegaCubeNew"); }
        else { prefabcube = Resources.Load<GameObject>("Prefabs/CubeOne"); }

        var megacube = Instantiate(prefabcube, transform);
        megacube.SendMessage("IntPlayer", (object)player);
    }
}
