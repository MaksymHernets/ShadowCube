using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject door;
    public bool doot_stage = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (doot_stage)
            {
                doot_stage = false;
                StartCoroutine("Fade");
            }
        }
    }

    IEnumerator Fade()
    {
        door.transform.position = door.transform.position + new Vector3(0, 0 , 0.1f);
        yield return new WaitForSeconds(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
