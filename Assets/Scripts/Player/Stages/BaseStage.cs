using UnityEngine.Events;

public abstract class BaseStage
{
    public UnityEvent Finished = new UnityEvent();
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void Exit() { Finish(); }
    public void Finish() { Finished?.Invoke(); }
}