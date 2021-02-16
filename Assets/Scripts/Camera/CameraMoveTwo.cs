using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTwo : MonoBehaviour
{
    public Transform cameraa;
    public GameObject moveone;
    public GameObject canvas;
    public GameObject[] cubes;

    public float speed = 0.01f;
    float time = 0;
    bool key = true;

	private void Start()
	{
        
    }

	void Update()
    {
        canvas.SetActive(false);
        time += Time.deltaTime;
        if ( time > 1 && key )
		{
            key = false;
            StartCoroutine(Animation_Door());
        }
    }

	IEnumerator Animation_Door()
	{
        cubes[Cookie.room.IndexCube].SendMessage("OpenDoor", 4 , SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(6f);
        for (int i = 0; i < 40; ++i)
		{
			cameraa.transform.localPosition += new Vector3(speed, 0f, 0f);
			yield return new WaitForSeconds(0.02f);
        }
        moveone.SetActive(true);
        canvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
