using ShadowCube.DTO;
using UniRx;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
	public int indexCube
	{
		get
		{
			return PlayerPrefs.GetInt("IndexCube");
		}
		set
		{
			PlayerPrefs.SetInt("IndexCube", value);
			_indexCube.Value = value;
		}
	}

	public PlayerDTO playerDTO
	{
		get
		{
			return JsonUtility.FromJson<PlayerDTO>(PlayerPrefs.GetString("PlayerDTO"));
		}
		private set
		{
			var jsonplayer = JsonUtility.ToJson(value);
			PlayerPrefs.SetString("PlayerDTO", jsonplayer);
			_playerDTO.Value = value;
		}
	}

	private void Start()
	{
		if (!PlayerPrefs.HasKey("IndexCube"))
		{
			PlayerPrefs.SetInt("IndexCube", 0);
		}
		if (!PlayerPrefs.HasKey("PlayerDTO"))
		{
			var jsonplayer = JsonUtility.ToJson(new PlayerDTO());
			PlayerPrefs.SetString("PlayerDTO", jsonplayer);
		}

		_indexCube = new ReactiveProperty<int>();
		_playerDTO = new ReactiveProperty<PlayerDTO>();
	}

	public void UpdatePlayerDTO(PlayerDTO player)
	{
		playerDTO = player;
	}

	private ReactiveProperty<int> _indexCube;
	public IReadOnlyReactiveProperty<int> IndexCube => _indexCube;

	private ReactiveProperty<PlayerDTO> _playerDTO;
	public IReadOnlyReactiveProperty<PlayerDTO> PlayerDTO => _playerDTO;
}
