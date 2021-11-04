using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ShadowCube.Setting;
using UniRx;

[RequireComponent(typeof(Camera))]
public class SnapshotModeSelect : MonoBehaviour
{
    [SerializeField] private int filterIndex = 0;
    [SerializeField] private Shader[] Shaders;

    private List<SnapshotFilter> filters = new List<SnapshotFilter>();

    [Inject] GraphicSetting graphicSetting;

    private void Awake()
    {
        foreach (var shader in Shaders)
        {
            filters.Add(new BaseFilter("None", Color.white, shader));
        }

        filterIndex = graphicSetting.screenEffect;
    }

	private void Start()
	{
        graphicSetting.ScreenEffect.AsObservable().Subscribe(Handler_ScreenEffect);
    }

    private void Handler_ScreenEffect(int newindex)
	{
        filterIndex = newindex;
    }

	private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        filters[filterIndex].OnRenderImage(src, dst);
    }
}
