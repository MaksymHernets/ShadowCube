using Invector.vCharacterController;
using ShadowCube.DTO;
using UnityEngine;

public class PlayerLogic : Entity
{
    [SerializeField] private float distanceUse = 1;
    [SerializeField] private StatusPlayer statusPlayer = StatusPlayer.alive;
    [SerializeField] private vThirdPersonController vthirdPersonController;
    [SerializeField] private vThirdPersonCamera vthirdPersonCamera;
    [SerializeField] private AudioSource foolman;

    private PlayerDTO _player;
    private InteractiveObject TakeObject;

	#region temp
	private int _WC = Screen.width / 2;
    private int _HC = Screen.height / 2;
    private RaycastHit hit;
    private Ray ray;
    private float forcee = 4f;
    #endregion

    void Start()
    {
        eventDie.AddListener(EventDie_Handler);
    }

	public void Init(PlayerDTO player)
	{
        _player = player;
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
            TakeObject.Rigidbody.AddForce(new Vector3(transform.localRotation.x * forcee, transform.localRotation.y * forcee, transform.localRotation.z * forcee)
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
                    hit.transform.SendMessage("Using", SendMessageOptions.DontRequireReceiver);
                }
                else if ( hit.transform.gameObject.GetComponent<InteractiveObject>() )
                {
                    hit.transform.gameObject.GetComponent<InteractiveObject>().Taken(this.transform);
                }
            }
        }
    }

    public void OpenItem()
	{
        //itemsui.Show();
    }

	private void OnCollisionEnter(Collision collision)
	{
		if ( collision.transform.tag == "Floor")
		{
            foolman.Play();
        }
	}

	private void OnTriggerEnter(Collider other)
	{
		if ( other.transform.tag == "Cube")
		{
            _player.score.Rooms++;
		}
	}

	private void OnCollisionStay(Collision collision)
	{
        if (collision.transform.tag == "Damage")
        {
            ToDamage(new Damage() { value = 5 });
        }
    }

    public void EventDie_Handler()
    {
	    vthirdPersonController.enabled = false;
	    vthirdPersonCamera.enabled = false;
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