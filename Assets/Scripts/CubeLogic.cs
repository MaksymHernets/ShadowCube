using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    public Cube cube;

    public List<Light> lights;

    // Start is called before the first frame update
    void Start()
    {
		
    }

    public void IntCube(object cubee)
	{
        cube = (Cube)cubee;
        foreach (var light in lights)
        {
            light.color = cube.Color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Cube
{
    public Guid id;

    public Color Color;

    public Trap trap;
}

public class Trap
{

}
