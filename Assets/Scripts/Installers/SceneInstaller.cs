using UnityEngine;
using Zenject;

namespace Installers
{
	public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GenericSetting _genericSetting = new GenericSetting();

        public override void InstallBindings()
        {
            Container.Bind<GenericSetting>().FromInstance(_genericSetting).Lazy();
        }
    }
}
