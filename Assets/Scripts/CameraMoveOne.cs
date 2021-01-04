using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveOne : MonoBehaviour
{
    public Transform camera;

    public float k = 0.2f;
    public float kk = 30;
    public float start = 0;
    public bool key = true;
    public bool keyy = false;

    void Start()
	{
        start = camera.localEulerAngles.y;
    }

	void Update()
    {
        if ( key )
		{

            camera.localEulerAngles = new Vector3(camera.localEulerAngles.x, camera.localEulerAngles.y + k, camera.localEulerAngles.z);
            if ( camera.localEulerAngles.y > start + kk)
            {
                key = false;
            }
        }
        else
		{
            camera.localEulerAngles = new Vector3(camera.localEulerAngles.x, camera.localEulerAngles.y - k, camera.localEulerAngles.z);
            if ( camera.localEulerAngles.y < start - kk)
            {
                key = true;
            }
        }
        
    }
}
