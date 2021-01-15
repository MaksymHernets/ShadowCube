using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SnapshotModeSelect : MonoBehaviour
{
    public Shader[] Shaders;

    private List<SnapshotFilter> filters = new List<SnapshotFilter>();

    public int filterIndex = 0;

    private void Awake()
    {
        foreach (var shader in Shaders)
        {
            filters.Add(new BaseFilter("None", Color.white, shader));
        }
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        filters[filterIndex].OnRenderImage(src, dst);
    }
}
