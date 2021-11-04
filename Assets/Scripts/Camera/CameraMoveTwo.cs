using Cubes;
using ShadowCube.Setting;
using System.Collections;
using UnityEngine;
using Zenject;

public class CameraMoveTwo : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private GameObject moveone;
    [SerializeField] private GameObject canvas;
    [SerializeField] private CubeLogic[] cubes;

    [SerializeField] private float speed = 0.01f;

    [Inject] GameSetting gameSetting;

    private float time = 0;
    private bool key = true;

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
        cubes[gameSetting.indexCube].OpenDoor(4);
        yield return new WaitForSeconds(6f);
        for (int i = 0; i < 40; ++i)
		{
			mainCamera.transform.localPosition += new Vector3(speed, 0f, 0f);
			yield return new WaitForSeconds(0.02f);
        }
        moveone.SetActive(true);
        canvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
