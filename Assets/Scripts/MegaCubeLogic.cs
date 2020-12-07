using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class MegaCubeLogic : MonoBehaviour
{
    public GameObject cube;

    public int Size;
    public float k = 1.6f;

    // Start is called before the first frame update
    void Start()
    {
        Random random = new Random();
		for (int i = 0; i < Size; i++)
		{
            for (int j = 0; j < Size; j++)
            {
                for (int l = 0; l < Size; l++)
                {
                    var transform = cube.transform;
                    var newcube = Instantiate(cube, new Vector3(i * k, j * k, l * k), transform.rotation);
                    var cubee = new Cube() { id = Guid.NewGuid(), Color = Random.ColorHSV() };
                    newcube.SendMessage("IntCube", (object)cubee);
                }
            }
        }
    }

    private Color GetColor(int index)
	{
        if (index == 0) { return Color.white;  }
        else if (index == 1) { return Color.red; }
        else if (index == 2) { return Color.yellow; }
        else if (index == 3) { return Color.blue; }
        else if (index == 4) { return Color.green; }
        else if (index == 5) { return Color.gray; }
        else if (index == 6) { return Color.magenta; }
        return Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
