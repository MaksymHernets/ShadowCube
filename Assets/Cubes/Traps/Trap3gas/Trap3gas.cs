﻿using ShadowCube.DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap3gas : MonoBehaviour
{
    public float SizeCube = 1f;
    private bool key = true;

    public GameObject prewall;
    public GameObject colliderDamage;

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

            foreach (var item in walls)
            {
                item.SetActive(true);
            }
            StartCoroutine("Waiting");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Entity>() != null)
        {
            other.gameObject.GetComponent<Entity>().ToDamage(new Damage() { type = TypeDamage.venom, value = 1 });
        }
    }

    IEnumerator Waiting()
    {
        colliderDamage.SetActive(true);
        yield return new WaitForSecondsRealtime(7);
        foreach (var item in walls)
        {
            item.SetActive(false);
        }
        key = true;
    }

}

