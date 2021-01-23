using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTransform : MonoBehaviour
{
    public IEnumerable CoroutinePosition(float time, GameObject start, Vector3 end)
	{
        float sumtime = 0;
        while (time >= sumtime)
        {
            sumtime += Time.deltaTime;
            start.transform.localPosition = Vector3.Lerp(start.transform.localPosition, end, Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerable CoroutinePosition(float time, GameObject start, Vector3 end, string nextCoroutine)
    {
        yield return null;
        CoroutinePosition(time, start, end);
        StartCoroutine(nextCoroutine);
    }
}
