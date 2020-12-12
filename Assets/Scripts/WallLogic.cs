using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WallLogic : MonoBehaviour
{
    private int indexwall = 0;

    public TextMesh number1;
    public TextMesh number2;
    public TextMesh number3;
    public TextMesh number4;
    public TextMesh number5;
    public TextMesh number6;

    public GameObject cube;
    public GameObject door;

    public void IntWall(object cubee) // Gameobject
    {
        cube = (GameObject)cubee;
    }

    public void IntWallIndex(object index) // index
	{
        indexwall = (int)index;
    }

    public void IntWallId(object index) // index
    {
        var number = (Vector3Int)index;
        number1.text = number.x.ToString();
        number2.text = number.y.ToString();
        number3.text = number.z.ToString();
        number4.text = number.x.ToString();
        number5.text = number.y.ToString();
        number6.text = number.z.ToString();
    }

    public void ToOpenDoor()
	{
        Debug.Log("ToOpenDoor");
        door.SendMessage("MegaCubeToOpen");
    }

    public void OpenedDoor()
	{
        Debug.Log("OpenedDoor");
        cube.SendMessage("EventOpenedDoor", (object)indexwall);
    }
}
