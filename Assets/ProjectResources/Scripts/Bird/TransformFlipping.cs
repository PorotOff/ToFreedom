using UnityEngine;

public class TransformFlipping
{
    private Transform objectTransform;

    public TransformFlipping(Transform objectTransform)
    {
        this.objectTransform = objectTransform;
    }

    public void FlipByX()
    {
        Vector2 newLocalScale = objectTransform.localScale;
        newLocalScale.x = objectTransform.localScale.x * -1;

        objectTransform.transform.localScale = newLocalScale;
    }
}