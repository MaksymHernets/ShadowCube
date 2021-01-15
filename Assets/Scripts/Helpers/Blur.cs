using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
	[RequireComponent(typeof(Camera))]
	public class Blur : MonoBehaviour
	{
        protected Material mainMaterial;
        public Shader shader;

        private void Awake()
        {
            mainMaterial = new Material(shader);
            mainMaterial.SetInt("_KernelSize", 100);
        }

        public void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            //filters[filterIndex].OnRenderImage(src, dst);

            RenderTexture tmp = RenderTexture.GetTemporary(src.width, src.height, 0, src.format);

            // Perform both passes in order.
            Graphics.Blit(src, tmp, mainMaterial, 0);   // First pass.
            Graphics.Blit(tmp, dst, mainMaterial, 1);   // Second pass.

            //shaderMaterial = new RenderTexture();

            //Graphics.Blit(src, intermediateRT, shaderMaterial);
            //Graphics.Blit(intermediateRT, dst);

            RenderTexture.ReleaseTemporary(tmp);
        }
    }
}
