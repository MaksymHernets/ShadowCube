using ShadowCube.DTO;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ShadowCube.Setting
{
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
				IndexCube.Value = value;
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
				PlayerDTO.Value = value;
			}
		}

		public List<PlayerDTO> players
		{
			get;
			set;
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

			IndexCube = new ReactiveProperty<int>();
			PlayerDTO = new ReactiveProperty<PlayerDTO>();
		}

		public void UpdatePlayerDTO(PlayerDTO player)
		{
			playerDTO = player;
		}

		public ReactiveProperty<int> IndexCube;

		public ReactiveProperty<PlayerDTO> PlayerDTO;
	}
}