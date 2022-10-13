﻿using ShadowCube.Cubes;
using ShadowCube.DTO;
using ShadowCube.Helpers;
using UnityEngine;

namespace ShadowCube.Player
{
	public class PlayerLogic : PlayerMoveControl, IPlayerLogic
    {
        [Header("Status")]
        [SerializeField] private float distanceUse = 1;
        [SerializeField] public StatusPlayer statusPlayer;
        [SerializeField] private AudioSource foolman;

        //[SerializeField] private vThirdPersonController vthirdPersonController;
        //[SerializeField] private vThirdPersonCamera vthirdPersonCamera;

        private PlayerDTO _player;
        private InteractiveObject TakeObject;
        private PlayerController _playerController;

        #region temp
        private int _WC = Screen.width / 2;
        private int _HC = Screen.height / 2;
        private RaycastHit hit;
        private Ray ray;
        private float forcee = 4f;
        #endregion

        protected new void Start()
        {
            EventDie.AddListener(EventDie_Handler);
            statusPlayer = StatusPlayer.alive;

            base.Start();
        }

        public void Init(PlayerController playerController, PlayerDTO player)
        {
            _playerController = playerController;
            _player = player;
        }

        public void ToUse()
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(_WC, _HC, 0f));

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance <= distanceUse)
                {
                    if (hit.transform.gameObject.GetComponent<DoorLogic>())
                    {
                        hit.transform.gameObject.GetComponent<DoorLogic>().Open();
                    }
                    else if (hit.transform.gameObject.GetComponent<InteractiveObject>())
                    {
                        hit.transform.gameObject.GetComponent<InteractiveObject>().Taken(this.transform);
                    }
                }
            }
        }

        public void DropItem()
        {
            TakeObject.GetComponent<Rigidbody>().useGravity = true;
            TakeObject.Rigidbody.AddForce(
                new Vector3(transform.localRotation.x * forcee, transform.localRotation.y * forcee, transform.localRotation.z * forcee)
                , ForceMode.Impulse);
            TakeObject.transform.parent = null;
            TakeObject = null;
        }

        public void OpenInventory()
        {
            _playerController.OpenInventary();
        }

        private void EventDie_Handler()
        {
            //vthirdPersonController.enabled = false;
            //vthirdPersonCamera.enabled = false;
            gameObject.SetActive(false);
            statusPlayer = StatusPlayer.die;
        }
	}

    public interface IPlayerLogic
    {
        void ToUse();
        void OpenInventory();
        void DropItem();
    }

    public enum StatusPlayer
    {
        sleep,
        alive,
        die
    }
}