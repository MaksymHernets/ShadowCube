using UnityEngine;

public class CameraMoveOne : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;

    public float k = 0.2f;
    public float kk = 30;
    public float start = 0;
    public bool key = true;

    void Start()
	{
        start = mainCamera.localEulerAngles.y;
    }

	void Update()
    {
        if ( key )
		{
            mainCamera.localEulerAngles = new Vector3(mainCamera.localEulerAngles.x, mainCamera.localEulerAngles.y + k, mainCamera.localEulerAngles.z);
            if ( mainCamera.localEulerAngles.y > start + kk)
            {
                key = false;
            }
        }
        else
		{
            mainCamera.localEulerAngles = new Vector3(mainCamera.localEulerAngles.x, mainCamera.localEulerAngles.y - k, mainCamera.localEulerAngles.z);
            if ( mainCamera.localEulerAngles.y < start - kk)
            {
                key = true;
            }
        }
        
    }
}
