using ShadowCube.Player;
using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube
{
    public class BaseStage : MonoBehaviour
    {
        public UnityAction EventFinished;

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Exit()
        {

        }

        public void Finish()
        {
            EventFinished?.Invoke();
        }
            
    }
}
