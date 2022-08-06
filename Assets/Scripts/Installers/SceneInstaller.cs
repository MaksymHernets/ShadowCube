using ShadowCube.Setting;
using UnityEngine;
using Zenject;

namespace ShadowCube.Installers
{
	public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GenericSetting _genericSetting = new GenericSetting();
        [SerializeField] private ControlSetting _controlSetting = new ControlSetting();
        [SerializeField] private GraphicSetting _graphicSetting = new GraphicSetting();
        [SerializeField] private ScreenSetting _screenSetting = new ScreenSetting();
        [SerializeField] private GameSetting _gameSetting = new GameSetting();

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
