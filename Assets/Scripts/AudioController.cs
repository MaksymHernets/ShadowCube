using ShadowCube.Setting;
using UnityEngine;
using Zenject;
using UniRx;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
	private AudioSource _audioSource;

	//[Inject] GenericSetting genericSetting;

	private void Start()
	{
		_audioSource = gameObject.GetComponent<AudioSource>();

		//genericSetting._globalSound.AsObservable().Subscribe(Handler_ChangeSound);
	}

	private void Handler_ChangeSound(float newvalue)
	{
		_audioSource.volume = newvalue;
	}

	public enum AudioLayer
	{
		Sound = 0,
		Music = 1,
		Effect = 2
	}
}
