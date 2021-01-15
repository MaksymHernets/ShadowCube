using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveOne : MonoBehaviour
{
    public Transform cameraa;

    public float k = 0.2f;
    public float kk = 30;
    public float start = 0;
    public bool key = true;
    public bool keyy = false;

    void Start()
	{
        start = cameraa.localEulerAngles.y;
    }

	void Update()
    {
        if ( key )
		{
            cameraa.localEulerAngles = new Vector3(cameraa.localEulerAngles.x, cameraa.localEulerAngles.y + k, cameraa.localEulerAngles.z);
            if ( cameraa.localEulerAngles.y > start + kk)
            {
                key = false;
            }
        }
        else
		{
            cameraa.localEulerAngles = new Vector3(cameraa.localEulerAngles.x, cameraa.localEulerAngles.y - k, cameraa.localEulerAngles.z);
            if ( cameraa.localEulerAngles.y < start - kk)
            {
                key = true;
            }
        }
        
    }
}
