using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ShadowCube.DTO;

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
            StartCoroutine(Animation_Show(1f, Quaternion.Euler(-180f , 0f , 0f) ));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>() != null)
        {
            other.gameObject.GetComponent<Entity>().ToDamage(new Damage() { type = TypeDamage.needles, value = 1 });
        }
    }

    IEnumerator Animation_Show(float time, Quaternion endP)
    {
        yield return new WaitForSecondsRealtime(2f);
		foreach (var mesh in meshs.Reverse() )
		{
            float sumtime = 0;
            while (time > sumtime)
            {
                sumtime += Time.deltaTime;
                mesh.transform.localRotation = Quaternion.Lerp(mesh.transform.localRotation, endP, Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }
        //Vector3.Lerp
        
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
