using ShadowCube.DTO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ControllerPlayMenu : IController
{
    [HideInInspector] public UnityEvent EventButtonPlayClick;

    [SerializeField] private Button buttonBack;
    [Header("BarUP")]
    [SerializeField] private Dropdown dropdownMap;
    [SerializeField] private Text buttonPrivatePublic;
    [SerializeField] private Text textCountPlayers;
    [SerializeField] private Toggle toggleAddBots;
    [SerializeField] private Button[] maps;
    [Header("Table")]

    [Header("BarDOWN")]
    [SerializeField] private Input inputCode;
    [SerializeField] private Button buttonStart;

    private RoomLoby room = new RoomLoby();
    private List<Entity> players = new List<Entity>();
    private ModelPlayMenu _model;

    public override void Init(IModel model)
	{
        _model = model as ModelPlayMenu;

        gameObject.SetActive(true);

        //room = Cookie.room;
        //dropdownMap.value = Cookie.room.IndexCube;
        //ChangedButton(0, Cookie.room.IndexCube);
    }

    private void Start()
    {
        buttonBack.onClick.AddListener(ButtonBack_Click);
        buttonStart.onClick.AddListener(ButtonStart_Click);
    }

    public void DropdownMap_Click(int newindex)
    {
        _model.mainMenuManager.ShowCube(room.IndexCube, newindex);
        room.IndexCube = newindex;
    }

    public void ButtonStart_Click()
    {
        if (toggleAddBots.isOn)
        {
            for (int i = 0; i < room.Size - players.Count; i++)
            {
                players.Add(new Entity());
            }
        }
        Cookie.room = room;
        Cookie.players = players;

        EventButtonPlayClick.Invoke();
    }

    #region Maps
    public void ButtonCubeOne_Click()
    {
        ChangedButton(room.IndexCube, 0);
    }

    public void ButtonHyberCube_Click()
    {
        ChangedButton(room.IndexCube, 1);
    }

    public void ButtonCubeZero_Click()
    {
        ChangedButton(room.IndexCube, 2);
    }

    public void ButtonNewCube_Click()
    {
        ChangedButton(room.IndexCube, 3);
    }

    public void ButtonCubeFour_Click()
    {
        ChangedButton(room.IndexCube, 4);
    }
    #endregion

    private void ChangedButton(int oldindex, int newindex)
    {
        if (oldindex != newindex)
        {
            room.IndexCube = newindex;
            maps[oldindex].image.color = new Color(0.3f, 0.3f, 0.3f, 0.8f);
            maps[newindex].image.color = Color.black;
            _model.mainMenuManager.ShowCube(oldindex, newindex);
        }
    }

    #region Property
    public void SliderPlayerCount_Click(float value)
    {
        room.Size = (int)value;
        textCountPlayers.text = value.ToString();
    }

    public void ButtonPrivatPublic_Click()
    {
        room.IsPrivate = !room.IsPrivate;
        if (room.IsPrivate)
        {
            buttonPrivatePublic.text = "Private";
        }
        else
        {
            buttonPrivatePublic.text = "Public";
        }
    }
    #endregion

    public void ButtonBack_Click()
    {
        Deactive();
        gameObject.SetActive(false);
    }
}
