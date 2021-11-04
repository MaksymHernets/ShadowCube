using UnityEngine;
using Zenject;

namespace Installers
{
	public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GenericSetting _genericSetting = new GenericSetting();
        [SerializeField] private GameSetting _gameSetting = new GameSetting();

        public override void InstallBindings()
        {
            Container.Bind<GenericSetting>().FromInstance(_genericSetting).Lazy();
            Container.Bind<GameSetting>().FromInstance(_gameSetting).Lazy();
        }
    }
}
