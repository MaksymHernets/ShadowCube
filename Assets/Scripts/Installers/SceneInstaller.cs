using ShadowCube.Setting;
using UnityEngine;
using Zenject;

namespace ShadowCube.Installers
{
	public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GenericSetting _genericSetting;
        [SerializeField] private ControlSetting _controlSetting;
        [SerializeField] private GraphicSetting _graphicSetting;
        [SerializeField] private ScreenSetting _screenSetting;
        [SerializeField] private GameSetting _gameSetting;

        public override void InstallBindings()
        {
            Container.Bind<ScreenSetting>().FromInstance(_screenSetting).Lazy();
            Container.Bind<GenericSetting>().FromInstance(_genericSetting).Lazy();
            Container.Bind<ControlSetting>().FromInstance(_controlSetting).Lazy();
            Container.Bind<GraphicSetting>().FromInstance(_graphicSetting).Lazy();
            Container.Bind<GameSetting>().FromInstance(_gameSetting).Lazy();
        }

		//private void Start()
		//{
  //          GameObject.DontDestroyOnLoad(this);
		//}
	}
}
