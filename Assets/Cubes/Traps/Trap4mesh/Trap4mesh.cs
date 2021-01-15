using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Trap4mesh : MonoBehaviour
{
    public GameObject[] meshs;

    public GameObject damage;

    private bool key = true;
    private float time = 0f;

    void OnTriggerEnter(Collider myTrigger)
    {
        if (key)
        {
            time = 0f;
            key = false;
			foreach (var item in meshs)
			{
				item.SetActive(true);
			}
			//audioSource.Play();
			damage.SetActive(true);
            StartCoroutine("Animation_Show");
        }
    }

    IEnumerator Animation_Show()
    {
        yield return new WaitForSecondsRealtime(4f);
		foreach (var mesh in meshs.Reverse() )
		{
            for (int i = 0; i <= 180; ++i)
            {
                mesh.transform.localEulerAngles = new Vector3(i, 0f, 0f);
                yield return new WaitForSecondsRealtime(0.005f);
            }
        }
        
        //StartCoroutine("Waiting");
    }

    void Update()
    {
        time += Time.deltaTime;
        if ( key == false && time > 10)
        {
            key = true;
        }
    }
}
