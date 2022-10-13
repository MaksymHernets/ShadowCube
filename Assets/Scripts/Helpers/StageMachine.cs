using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Helpers
{
	public class StageMachine
    {
        public BaseStage CurrentStage { get; protected set; }

        public StageMachine(BaseStage newStage)
		{
            CurrentStage = newStage;
            CurrentStage.Start();
        }

        public void SetStage(BaseStage newStage)
        {
            CurrentStage.Finished.AddListener(() => {
                CurrentStage = newStage;
                CurrentStage.Start();
            });
            CurrentStage?.Exit();
        }

        public void Update()
		{
            CurrentStage.Update();
        }
    }

    public abstract class BaseStage
    {
        public UnityEvent Finished = new UnityEvent();
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Exit() { Finish(); }
        public void Finish() { Finished?.Invoke(); }
    }
}
