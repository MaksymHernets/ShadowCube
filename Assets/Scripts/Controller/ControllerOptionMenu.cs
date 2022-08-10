using ShadowCube.Models;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowCube.Controller
{
	public class ControllerOptionMenu : IController
    {
        [SerializeField] private Button buttonBack;
        [SerializeField] private Animator _animator;

        [Header("BarUP")]
        [SerializeField] private SmartButtonUI[] buttons;

        [Header("Table")]
        [SerializeField] private OptionPanel[] panels;

        [Header("BarDown")]
        [SerializeField] private Button buttonDefault;
        [SerializeField] private Button buttonApply;

        private int index = 0;
        protected ModelOptionMenu _model;

        public override void Init(IModel model)
        {
            _model = model as ModelOptionMenu;

            if (panels.Length != 0) 
            {
                panels[index].gameObject.SetActive(true);
                foreach (var button in buttons)
			    {
                    button.OnClick += ButtonPanel;
                }
            }

            gameObject.SetActive(true);
        }

        private void Start()
        {
            buttonBack.onClick.AddListener(ButtonBack_Click);
            buttonDefault.onClick.AddListener(ButtonDefault_Click);
            buttonApply.onClick.AddListener(ButtonApply_Click);
        }

        public void ButtonPanel(Button button)
		{
            panels[index].gameObject.SetActive(false);
            index = 0;
            foreach (var item in buttons)
			{
                if (item == button)
				{
                    panels[index].gameObject.SetActive(true);
                    break;
                }
                ++index;
			}
        }

        public void ButtonDefault_Click()
        {
            panels[index].SetupDefaultOption();
        }

        public void ButtonApply_Click()
        {
            _animator.SetBool("Close", true);
            Invoke("Deactive", 3f);
        }

        public void ButtonBack_Click()
        {
            _animator.SetBool("Close", true);
            Invoke("Deactive", 3f);
        }
    }
}