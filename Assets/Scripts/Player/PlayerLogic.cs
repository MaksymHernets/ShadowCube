using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using ShadowCube.DTO;
using Playerr;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ShadowCube.UI;

public class PlayerLogic : MonoBehaviour
{
    private Player player;
    public StatusPlayer statusPlayer = StatusPlayer.alive;

    private float distanceUse = 1;

    public vThirdPersonController vthirdPersonController;
    public vThirdPersonCamera vthirdPersonCamera;
    public AudioSource foolman;

    public GameObject Menu;
    public ScoreUI scoreui;
    public FrameDamageUI frameDamageUI;
    public Items itemsui;

    private GameObject TakeObject;

	#region temp
	private int _WC = Screen.width / 2;
    private int _HC = Screen.height / 2;
    private RaycastHit hit;
    private Ray ray;
    private float starttime;
	#endregion

	void Start()
    {
        starttime = Time.realtimeSinceStartup;
        Cursor.visible = false;

        player = new Player();
        player.name = "player";
        player.id = 1;
    }

    public void IntPlayer(object objectPlayer)
	{
        player = (Player)objectPlayer;
    }

    public void Jump()
    {

    }
    public void ToUse()
	{
        ray = Camera.main.ScreenPointToRay(new Vector3(_WC, _HC, 0f));
        if (TakeObject != null)
        {
            TakeObject.GetComponent<Rigidbody>().useGravity = true;
            float forcee = 4f;
            //TakeObject.GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody2D>().AddTorque(360, ForceMode2D.Impulse);
            TakeObject.GetComponent<Rigidbody>()
                .AddForce(new Vector3(transform.localRotation.x * forcee, transform.localRotation.y * forcee, transform.localRotation.z * forcee)
                , ForceMode.Impulse);
            TakeObject.transform.parent = null;
            TakeObject = null;
        }
        else if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance <= distanceUse)
            {
                if (hit.transform.tag == "door")
                {
                    hit.transform.SendMessage("Using");
                }
                else if (hit.transform.tag == "object")
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

    public void OpenItem()
	{
        itemsui.Show();
    }

	private void OnCollisionEnter(Collision collision)
	{
		if ( collision.transform.tag == "Floor")
		{
            foolman.Play();
        }
	}

	//private void OnTriggerStay(Collider other)
	//{
	//    if (other.transform.tag == "Damage")
	//    {
	//        //Damage();
	//    }
	//}

	private void OnTriggerEnter(Collider other)
	{
		if ( other.transform.tag == "Cube")
		{
            player.score.Rooms++;
		}
	}

	private void OnCollisionStay(Collision collision)
	{
        if (collision.transform.tag == "Damage")
        {
            ToDamage(new Damage() { value = 5 });
        }
    }

    void ToDamage(Damage damage)
	{
        player.xp -= damage.value;
        frameDamageUI.Show(player.xp);
        if (player.xp <= 0) { ToDie(); }
    }

    public void ToDie()
    {
	    vthirdPersonController.enabled = false;
	    vthirdPersonCamera.enabled = false;
        Cursor.visible = true;
        player.score.Time = Time.realtimeSinceStartup - starttime;
        scoreui.Show(player.score);
        gameObject.SetActive(false);
        statusPlayer = StatusPlayer.die;
	}

}


 
public enum StatusPlayer
{
    sleep,
    alive,
    die
}