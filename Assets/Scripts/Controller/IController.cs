using ShadowCube.Models;
using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Controller
{
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
}
