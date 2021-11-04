using Cubes;
using ShadowCube.Setting;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlaceLogic : MonoBehaviour
{
    [SerializeField] private PlayerLogic _player;
    [SerializeField] private List<MegaCubeLogic> _megaCubes;

    private MegaCubeLogic _currentMegaCube;

    [Inject] GameSetting gameSetting;

    void Start()
    {
        _currentMegaCube = GameObject.Instantiate(_megaCubes[gameSetting.indexCube], transform);

		_currentMegaCube.Init();
		PutPlayer(_player);
	}

    private void PutPlayer(PlayerLogic playerLogic)
	{
		Vector3Int position = new Vector3Int();
		position.x = Random.Range(0, 15);
		position.y = Random.Range(0, 15);
		position.z = Random.Range(0, 15);

		_currentMegaCube.PutObject(position, playerLogic.gameObject.transform);
	}

    private void PutPlayers()
    {
		
	}
}
