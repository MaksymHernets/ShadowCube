using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.DTO
{
	public class Entity : MonoBehaviour, IDamage
    {
        [HideInInspector] public UnityEvent EventDie;
        [HideInInspector] public UnityEvent EventDamage;

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public float Health { get; set; }

		public virtual void ToDamage(Damage damage)
		{
            Health -= damage.value;

            if (Health <= 0)
			{
                EventDie.Invoke();
            }
        }
    }

    public interface IDamage
	{
        void ToDamage(Damage value);
	}

}
