using UnityEngine;

public abstract class Dynamic2DCameraModel
{
    protected Transform currentTransform { get; set; }
    protected Transform target { get; set; }
    protected float smoothness { get; set; }

	protected Vector3 newTargetPosition;

    public Dynamic2DCameraModel(Transform currentTransform, Transform target, float smoothness)
    {
        this.currentTransform = currentTransform;
        this.target = target;
        this.smoothness = smoothness;
    }

    protected abstract void MoveTo(Vector3 targetPosition);

    public abstract void MoveX();
    public abstract void MoveY();
    public abstract void MoveBoth();
}
