using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap5WalkWall : MonoBehaviour
{
    public GameObject prefab;
    public int Count = 50;
    public float Wight = 1f;

    private float speed = 0.02f;
    private List<GameObject> lists;
    private bool key = true;

    public AudioSource audioSource;

    void Start()
    {
        lists = new List<GameObject>();

        for (int i = 0; i < Count; ++i)
        {
            var newcube = Instantiate(prefab, transform);
            newcube.transform.localPosition = new Vector3(Random.Range(-Wight, Wight), Random.Range(-Wight, Wight), 1f);
            lists.Add(newcube);
        }
    }

    void OnTriggerEnter(Collider myTrigger)
    {
        if (key)
        {
            key = false;
            foreach (var item in lists)
            {
                item.SetActive(true);
            }
            audioSource.Play();
            StartCoroutine("Animation_Show");
        }
    }

    IEnumerator Animation_Show()
    {
        yield return new WaitForSecondsRealtime(6f);
        for (int i = 0; i <= 100; ++i)
        {
            float Speed = i * speed;
            float Speed2 = 1 - i * speed/2;

            foreach (var item in lists)
            {
                item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y, Speed2);
                item.transform.localScale = new Vector3(item.transform.localScale.x, item.transform.localScale.y, Speed);
            }
            yield return new WaitForSecondsRealtime(0.3f);
        }
        StartCoroutine("Waiting");
    }

    IEnumerator Waiting()
    {
        //foreach (var item in walls)
        //{
        //    fire1.SendMessage("Play");
        //    fire2.SendMessage("Play");
        //}
        yield return new WaitForSecondsRealtime(5);
        key = true;
        //StartCoroutine("StageEnd");
    }
}
