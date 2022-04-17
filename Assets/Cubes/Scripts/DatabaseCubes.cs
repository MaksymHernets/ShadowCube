using ShadowCube.Cubes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;

namespace ShadowCube
{
    public static class DatabaseCubes
    {
        public static List<CubeLogic> GetCubes()
        {
            List<CubeLogic> cubes = new List<CubeLogic>();
            var locations = Addressables.LoadResourceLocationsAsync("cube", Addressables.MergeMode.Union, typeof(CubeLogic)).WaitForCompletion();

            if (locations != null)
            {
                cubes = Addressables.LoadAssetsAsync<CubeLogic>(locations, null).WaitForCompletion().ToList();
            }
            return cubes;
        }
    }
}
