using System.Collections;
using System.Collections.Generic;
using DTO;
using UI;
using Playerr;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public StatusPlayer statusPlayer = StatusPlayer.alive;

    public Image FrameBlood;
    public Image target;
    public GameObject Menu;
    public GameObject Blood;
    public GameObject Item;
    public Camera cameraa;
    public AudioSource foolman;

    private Player player;
    private Control control;
    public Score score;
    private Inventory inventory = new Inventory(10);

    private float xp = 100;
    private float distanceUse = 1;
    private GameObject TakeObject;

    private int _WC = Screen.width / 2;
    private int _HC = Screen.height / 2;
    private RaycastHit hit;
    private Ray ray;
    private float starttime;

    void Start()
    {
        score = new Score();
        score.scoreCube = new ScoreCube();

        starttime = Time.realtimeSinceStartup;
        Cursor.visible = false;

        player = new Player();
        player.name = "player";
        player.id = 1;
        control = new Control();
        control.use = KeyCode.Mouse0;
        control.openitem = KeyCode.Tab;
    }

    public void IntPlayer(object objectPlayer)
	{
        player = (Player)objectPlayer;
    }

    void Update()
    {
        if ( Input.GetKeyDown(control.use) )
		{
            ray = cameraa.ScreenPointToRay(new Vector3(_WC, _HC, 0f));
            if ( TakeObject != null)
            {
                TakeObject.GetComponent<Rigidbody>().useGravity = true;
                float forcee = 4f;
                //TakeObject.GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody2D>().AddTorque(360, ForceMode2D.Impulse);
                TakeObject.GetComponent<Rigidbody>()
                    .AddForce(new Vector3(transform.localRotation.x* forcee, transform.localRotation.y* forcee, transform.localRotation.z* forcee)
                    , ForceMode.Impulse);
                TakeObject.transform.parent = null;
                TakeObject = null;
            }
            else if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance <= distanceUse)
				{
                    if ( hit.transform.tag == "door" )
					{
                        hit.transform.SendMessage("Using");
                    }
                    else if( hit.transform.tag == "object" )
					{
                        //listItems
                        //TakeObject = hit.transform.gameObject;
                        //TakeObject.GetComponent<Rigidbody>().useGravity = false;
                        ////TakeObject.GetComponent<Rigidbody>().isKinematic = false;
                        //hit.transform.parent = target.transform;
                    }
                }
            }
        }
        else if(Input.GetKeyDown(control.openitem) )
        {
            Item.SetActive(!Item.activeSelf);
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
		if ( collision.transform.tag == "Floor")
		{
            foolman.Play();
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Damage")
        {
            //Damage();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if ( other.transform.tag == "Cube")
		{
            score.scoreCube.Rooms++;
		}
	}

	private void OnCollisionStay(Collision collision)
	{
        if (collision.transform.tag == "Damage")
        {
            //ToDamage();
        }
    }

    void ToDamage(Damage damage)
	{
        xp -= damage.value;
        FrameBlood.color = new Color(FrameBlood.color.r, FrameBlood.color.g, FrameBlood.color.b, 1 - xp * 0.01f);
        if (xp <= 0) { ToDie(); }
    }

    public void ToDie()
	{
        Cursor.visible = true;
        Blood.SetActive(true);
        gameObject.SetActive(false);

        statusPlayer = StatusPlayer.die;
	}

}

public class Damage
{
    public TypeDamage type { get; set; }
    public int value { get; set; }
}

public enum TypeDamage
{
    needles,
    fire,
    venom,
    cool,
    fool
}

public enum StatusPlayer
{
    sleep,
    alive,
    die
}