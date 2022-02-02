using UnityEngine;

namespace ShadowCube.Helpers
{
	public class InteractiveObject : MonoBehaviour
	{
		public Rigidbody Rigidbody { get; set; }

		private void Start()
		{
			Rigidbody = gameObject.GetComponent<Rigidbody>();
		}

		public void HeaveTo()
		{
			Rigidbody.isKinematic = true;
			Rigidbody.isKinematic = false;
		}

		public void Taken(Transform transform)
		{
			Rigidbody.useGravity = false;
			Rigidbody.isKinematic = false;
			transform.parent = transform;
		}

	}
}