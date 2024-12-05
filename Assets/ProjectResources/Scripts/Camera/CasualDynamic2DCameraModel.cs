using UnityEngine;

public class CasualDynamic2DCameraModel : Dynamic2DCameraModel
{
    public CasualDynamic2DCameraModel(Transform currentTransform, Transform target, float smoothness)
        : base(currentTransform, target, smoothness) { }

    public override void MoveX()
    {
        newTargetPosition = new Vector3(target.position.x, currentTransform.position.y, currentTransform.position.z);
        MoveTo(newTargetPosition);
    }

    public override void MoveY()
    {
        newTargetPosition = new Vector3(currentTransform.position.x, target.position.y, currentTransform.position.z);
        MoveTo(newTargetPosition);
    }

    public override void MoveBoth()
    {
        newTargetPosition = new Vector3(target.position.x, target.position.y, currentTransform.position.z);
        MoveTo(newTargetPosition);
    }

    protected override void MoveTo(Vector3 targetPosition)
    {
        currentTransform.position = targetPosition;
    }
}
