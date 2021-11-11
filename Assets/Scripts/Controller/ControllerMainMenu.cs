using ShadowCube.Models;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ShadowCube.Controller
{
    public class ControllerMainMenu : IController
    {
        public UnityAction<string> EventButtonClick;

        [SerializeField] private Animator _animator;
        [SerializeField] private Text textVersion;
        [SerializeField] private Button buttonPlay;
        [SerializeField] private Button buttonOnline;
        [SerializeField] private Button buttonPerson;
        [SerializeField] private Button buttonOptions;
        [SerializeField] private Button buttonAbout;
        [SerializeField] private Button buttonExit;

        protected ModelMainMenu _model;

        public override void Init(IModel model)
        {
            _model = model as ModelMainMenu;

            gameObject.SetActive(true);

            textVersion.text = "ALPHA " + Application.version;
        }

        private void Start()
        {
            buttonPlay.onClick.AddListener(ButtonPlay_Click);
            buttonOnline.onClick.AddListener(ButtonOnline_Click);
            buttonPerson.onClick.AddListener(ButtonPerson_Click);
            buttonOptions.onClick.AddListener(ButtonOptions_Click);
            buttonAbout.onClick.AddListener(ButtonAbout_Click);
            buttonExit.onClick.AddListener(ButtonExit_Click);
        }

        public void ButtonPlay_Click()
        {
            EventButtonClick.Invoke("PlayMenu");
        }

        public void ButtonOnline_Click()
        {
            EventButtonClick.Invoke("OnlineMenu");
        }

        public void ButtonPerson_Click()
        {
            EventButtonClick.Invoke("PersonMenu");
        }

        public void ButtonOptions_Click()
        {
            EventButtonClick.Invoke("OptionMenu");
        }

        public void ButtonAbout_Click()
        {
            EventButtonClick.Invoke("AboutMenu");
        }

        public void ButtonExit_Click()
        {
            Application.Quit();
        }

        public override void Deactive()
        {
            _animator.SetBool("Close", true);
            Observable.Timer(System.TimeSpan.FromSeconds(2.5f))
            .Subscribe(_ => { base.Deactive(); });
        }
    }
}