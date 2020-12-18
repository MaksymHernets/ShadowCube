using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWallLogic : MonoBehaviour
{
        public List<GameObject> lists;

        public void Go()
        {
            StartCoroutine("Animation_Needler");
            
        }

        public void Down()
        {
            StartCoroutine("Animation_Needler2");
        }

        IEnumerator Animation_Needler2()
        {
            for (int i = 20; i >= 0; --i)
            {
                foreach (var item in lists)
                {
                    item.transform.localPosition = new Vector3(item.transform.localPosition.x, i * 0.05f, item.transform.localPosition.z);
                    item.transform.localScale = new Vector3(item.transform.localScale.x, i * 0.05f, item.transform.localScale.z);
                    yield return null;
                }
            }
        }

        IEnumerator Animation_Needler()
        {
            for (int i = 0; i < 20; i++)
            {
                foreach (var item in lists)
                {
                    item.transform.localPosition = new Vector3(item.transform.localPosition.x, i * 0.05f, item.transform.localPosition.z);
                    item.transform.localScale = new Vector3(item.transform.localScale.x, i * 0.05f, item.transform.localScale.z);
                    yield return null;
                }
            }

		    for (int i = 20; i >= 0; --i)
		    {
			    foreach (var item in lists)
			    {
				    item.transform.localPosition = new Vector3(item.transform.localPosition.x, i * 0.05f, item.transform.localPosition.z);
				    item.transform.localScale = new Vector3(item.transform.localScale.x, i * 0.05f, item.transform.localScale.z);
				    yield return null;
			    }
		    }

            Destroy(gameObject);
	    }
}
