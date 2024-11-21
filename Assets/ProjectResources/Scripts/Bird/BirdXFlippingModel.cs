using UnityEngine;

public class BirdXFlippingModel
{
    private Transform birdTransform;

    public BirdXFlippingModel(Transform birdTransform)
    {
        this.birdTransform = birdTransform;
    }

    public void FlipByX()
    {
        Vector2 newLocalScale = birdTransform.localScale;
        newLocalScale.x = birdTransform.localScale.x * -1;

        birdTransform.transform.localScale = newLocalScale;
    }
}