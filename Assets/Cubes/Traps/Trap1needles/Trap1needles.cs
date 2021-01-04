using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1needles : MonoBehaviour
{
    public float SizeCube = 1f;
    private float speed = 0.0125f;
    private bool key = true;

    public GameObject prewall;
    public AudioSource noizeup;
    public AudioSource noizedown;

    private List<GameObject> walls;

    private void Start()
    {
        walls = new List<GameObject>();

        for (int i = 0; i < 6; i++)
        {
            var newwall = Instantiate(prewall, transform);
            walls.Add(newwall);
        }

        walls[1].transform.localPosition = new Vector3(0, 0, 1);
        walls[2].transform.localPosition = new Vector3(1, 0, 0);
        walls[3].transform.localPosition = new Vector3(0, 0, -1);
        walls[4].transform.localPosition = new Vector3(-1, 0, 0);
        walls[5].transform.localPosition = new Vector3(0, 1, 0);

        walls[1].transform.localRotation = Quaternion.Euler(90, 90, 270);
        walls[2].transform.localRotation = Quaternion.Euler(90, 90, 180);
        walls[3].transform.localRotation = Quaternion.Euler(90, 90, -270);
        walls[4].transform.localRotation = Quaternion.Euler(90, -90, -180);
        walls[5].transform.localRotation = Quaternion.Euler(0, 0, 180);
    }

    void OnTriggerEnter(Collider myTrigger)
    {
        if (key)
        {
            key = false;
            
            foreach (var wall in walls)
            {
                wall.SetActive(true);
            }
            StartCoroutine("Animation_Show");
        }
    }

    IEnumerator Animation_Show()
    {
        noizeup.Play();
        for (int i = 0; i <= 40; ++i)
        {
            float Speed = i * speed;
            float Speed2 = 1-Speed;
            walls[0].transform.localPosition = new Vector3(0, -Speed2, 0);
            walls[1].transform.localPosition = new Vector3(0, 0, Speed2);
            walls[2].transform.localPosition = new Vector3(Speed2, 0, 0);
            walls[3].transform.localPosition = new Vector3(0, 0, -Speed2);
            walls[4].transform.localPosition = new Vector3(-Speed2, 0, 0);
            walls[5].transform.localPosition = new Vector3(0, Speed2, 0);

            walls[0].transform.localScale = new Vector3(1, Speed, 1);
            walls[1].transform.localScale = new Vector3(1, Speed, 1);
            walls[2].transform.localScale = new Vector3(1, Speed, 1);
            walls[3].transform.localScale = new Vector3(1, Speed, 1);
            walls[4].transform.localScale = new Vector3(1, Speed, 1);
            walls[5].transform.localScale = new Vector3(1, Speed, 1);

            yield return new WaitForSecondsRealtime(0.05f);
        }
        StartCoroutine("Waiting");
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSecondsRealtime(5);
        StartCoroutine("Animation_Down");
    }

    IEnumerator Animation_Down()
    {
        noizedown.Play();
        for (int i = 40; i >= 0; --i)
        {
            float Speed = i * speed;
            float Speed2 = 1 - Speed;
            walls[0].transform.localPosition = new Vector3(0, -Speed2, 0);
            walls[1].transform.localPosition = new Vector3(0, 0, Speed2);
            walls[2].transform.localPosition = new Vector3(Speed2, 0, 0);
            walls[3].transform.localPosition = new Vector3(0, 0, -Speed2);
            walls[4].transform.localPosition = new Vector3(-Speed2, 0, 0);
            walls[5].transform.localPosition = new Vector3(0, Speed2, 0);

            walls[0].transform.localScale = new Vector3(1, Speed, 1);
            walls[1].transform.localScale = new Vector3(1, Speed, 1);
            walls[2].transform.localScale = new Vector3(1, Speed, 1);
            walls[3].transform.localScale = new Vector3(1, Speed, 1);
            walls[4].transform.localScale = new Vector3(1, Speed, 1);
            walls[5].transform.localScale = new Vector3(1, Speed, 1);

            yield return new WaitForSecondsRealtime(0.09f);
        }

        foreach (var wall in walls)
        {
            wall.SetActive(false);
        }
        key = true;
    }

    
}

