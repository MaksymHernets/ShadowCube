using UniRx;
using UnityEngine;

public class GenericSetting : MonoBehaviour
{
    public float globalSound
	{
        get
		{
			return PlayerPrefs.GetFloat("GlobalSound");
		}
        set
		{
			PlayerPrefs.SetFloat("GlobalSound", value);
			AudioListener.volume = value * 0.01f;
			_globalSound.Value = value;
		}
	}

    public float globalMusic
	{
		get
		{
			return PlayerPrefs.GetFloat("GlobalMusic");
		}
		set
		{
			PlayerPrefs.SetFloat("GlobalMusic", value);
			_globalSound.Value = value;
		}
	}

    public int language
	{
		get
		{
			return PlayerPrefs.GetInt("Language");
		}
		set
		{
			PlayerPrefs.SetInt("Language", value);
			_launcher.Value = value;
		}
	}

	private void Start()
	{
		if (!PlayerPrefs.HasKey("GlobalSound"))
		{
			PlayerPrefs.SetFloat("GlobalSound", 0f);
		}
		if (!PlayerPrefs.HasKey("GlobalMusic"))
		{
			PlayerPrefs.SetFloat("GlobalMusic", 0f);
		}
		if (!PlayerPrefs.HasKey("Launcher"))
		{
			PlayerPrefs.SetInt("Launcher", 0);
		}

		AudioListener.volume = PlayerPrefs.GetFloat("GlobalSound") * 0.01f;

		_globalSound = new ReactiveProperty<float>(globalSound);
		_globalMusic = new ReactiveProperty<float>(globalMusic);
		_launcher = new ReactiveProperty<int>(language);
	}

	private ReactiveProperty<float> _globalSound;
	public IReadOnlyReactiveProperty<float> GlobalSound => _globalSound;

	private ReactiveProperty<float> _globalMusic;
	public IReadOnlyReactiveProperty<float> GlobalMusic => _globalMusic;

	private ReactiveProperty<int> _launcher;
	public IReadOnlyReactiveProperty<int> Launcher => _launcher;
}
