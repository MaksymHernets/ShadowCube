using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShadowCube.Scenes
{
	public class FirstLoadManager : MonoBehaviour
    {
        [SerializeField] private Image image;

        private AsyncOperation _asyncOperation;

        void Start()
        {
            StartCoroutine( StartLoad() );
        }

        private IEnumerator StartLoad()
        {
            yield return new WaitForEndOfFrame();
            _asyncOperation = SceneManager.LoadSceneAsync(1);
        }

        private void Update()
		{
            if (_asyncOperation != null) image.fillAmount = _asyncOperation.progress;
        }
	}
}
