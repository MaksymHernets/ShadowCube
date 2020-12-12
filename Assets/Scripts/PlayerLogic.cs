using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    private Player player;

    private Control control;

    public Camera cameraa;

    private float distanceUse = 1;
    private float xp = 100;

    public Text textxp;
    public GameObject menu;
    public Image target;

    private int _WC = Screen.width / 2;
    private int _HC = Screen.height / 2;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        

        player = new Player();
        player.name = "player";
        player.id = 1;
        control = new Control();
        control.use = KeyCode.Mouse0;
        control.openitem = KeyCode.Tab;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(control.use) )
		{
            RaycastHit hit;
            //Ray ray = cameraa.ScreenPointToRay(Vector3.zero);
            Ray ray = cameraa.ScreenPointToRay(new Vector3(_WC, _HC, 0f));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance <= distanceUse)
				{
                    if ( hit.transform.tag == "door" )
					{
                        hit.transform.SendMessage("UserToOpen");
                    }
                    else if( hit.transform.tag == "object" )
					{

					}
                }
            }
        }
    }


	private void OnCollisionStay(Collision collision)
	{
        LotOfDamage(collision);
    }

    public void LotOfDamage(Collision collision)
	{
        if (collision.transform.tag == "Damage")
        {
            xp -= 10;
            textxp.text = xp.ToString();
            if (xp <= 0)
            {
                textxp.text = "GAME OVER";
                menu.SetActive(true);
            }
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(.5f);
    }
}
