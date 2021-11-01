using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.DTO
{
	public class Entity : MonoBehaviour, IDamage
    {
        public UnityEvent eventDie { get; set; }
        public UnityEvent eventDamage { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public float Health { get; set; }

		private void Start()
		{
            eventDie = new UnityEvent();
            eventDamage = new UnityEvent();
        }

		public virtual void ToDamage(Damage damage)
		{
            Health -= damage.value;

            if (Health <= 0)
			{
                eventDie.Invoke();
            }
        }
    }

    public interface IDamage
	{
        void ToDamage(Damage value);
	}

}
