using ShadowCube.Config;
using ShadowCube.Controller;
using ShadowCube.DTO;
using ShadowCube.Models;
using ShadowCube.Player;
using ShadowCube.Setting;
using UnityEngine;
using Zenject;

namespace ShadowCube
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerLogic playerLogic;

        [Header("Controllers")]
        [SerializeField] private ControllerEndGame controllerEndGame;
        [SerializeField] private ControllerHUD controllerHUD;
        [SerializeField] private ControllerMenu controllerMenu;
        [SerializeField] private ControllerDisplayDamage controllerDisplayDamage;
        [SerializeField] private ControllerInventary controllerInventary;

        [SerializeField] private ItemsConfig itemsConfig;

        private ItemDTO[] items;

        private float timeStartLevel;
        private bool IsOpenInventary;

        [Inject] GameSetting gameSetting;

        void Start()
        {
            playerLogic.EventDie.AddListener(EventDie_Handler);

            controllerMenu.EventOpenedMenu.AddListener(EventOpenedMenu_Handler);
            controllerMenu.EventClosedMenu.AddListener(EventClosedMenu_Handler);

            SpawnItems();
            StartLevel();
        }

        private void SpawnItems()
        {
            items = new ItemDTO[24];

            var itemsDTO = itemsConfig.GetItems();
            items[0] = itemsDTO[0];
            items[1] = itemsDTO[1];
            items[2] = itemsDTO[2];
            items[3] = itemsDTO[3];

            items[21] = itemsDTO[4];
        }

        public void StartLevel()
        {
            timeStartLevel = 0f;

            playerLogic.Init(this, gameSetting.playerDTO);

            controllerEndGame.Init(new ModelEndGame() { playerController = this });
            controllerHUD.Init(new ModelHUD() { playerLogic = playerLogic });
            controllerMenu.Init(new IModel());
            controllerDisplayDamage.Init(new ModelDisplayDamage() { EntityTarget = playerLogic });
        }

        private void Update()
        {
            timeStartLevel += Time.deltaTime;
        }

        public void OpenInventary()
        {
            if (IsOpenInventary == false)
            {
                IsOpenInventary = true;
                controllerInventary.Init(new ModelInventary() { items = items });
            }
            else
            {
                IsOpenInventary = false;
                controllerInventary.Deactive();
            }
        }

        private void EventClosedMenu_Handler()
        {
            controllerHUD.Init(new ModelHUD() { playerLogic = playerLogic });
        }

        private void EventOpenedMenu_Handler()
        {
            controllerHUD.Deactive();
        }

        private void EventDie_Handler()
        {
            ModelEndGame model = new ModelEndGame();
            model.Time = timeStartLevel;

            controllerEndGame.Init(model);
        }
    }
}
