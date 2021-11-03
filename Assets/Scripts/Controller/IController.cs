using UnityEngine;
using UnityEngine.Events;

public abstract class IController : MonoBehaviour
{
	[HideInInspector] public UnityEvent EventClose;
	public abstract void Init(IModel model);
	
	public virtual void Deactive()
	{
		EventClose.Invoke();
		gameObject.SetActive(false);
	}
}
