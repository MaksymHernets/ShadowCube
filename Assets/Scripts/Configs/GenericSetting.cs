using UnityEngine;

public class GenericSetting
{
    public float _globalSound
	{
        get
		{
			return AudioListener.volume;
		}
        set
		{
			AudioListener.volume = value;
		}
	}

    public float _globalMusic
	{
		get
		{
			return PlayerPrefs.GetFloat("GlobalMusic");
		}
		set
		{
			PlayerPrefs.SetFloat("GlobalMusic", value);
		}
	}

    public int _launcher
	{
		get
		{
			return PlayerPrefs.GetInt("Launcher");
		}
		set
		{
			PlayerPrefs.SetInt("Launcher", value);
		}
	}

	public GenericSetting()
	{
		//if (!PlayerPrefs.HasKey("GlobalMusic"))
		//{
		//	PlayerPrefs.SetFloat("GlobalMusic", 0f);
		//}
		//if (!PlayerPrefs.HasKey("Launcher"))
		//{
		//	PlayerPrefs.SetInt("Launcher", 0);
		//}
	}

	//public IReadOnlyReactiveProperty<int> GlobalSound => _globalSound;

	//public IReadOnlyReactiveProperty<int> GlobalMusic => _globalMusic;

	//public IReadOnlyReactiveProperty<int> Launcher => _launcher;
}
