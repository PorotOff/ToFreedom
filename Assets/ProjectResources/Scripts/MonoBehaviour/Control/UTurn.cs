using UnityEngine;

public class UTurn
{
    private SpriteRenderer spriteRenderer { get; set; }

    private BirdMovement birdMovement { get; set; }

    public UTurn(BirdMovement birdMovement, SpriteRenderer spriteRenderer)
    {
        this.birdMovement = birdMovement;
        this.spriteRenderer = spriteRenderer;

        if (birdMovement.IsRightMovement())
        {
            spriteRenderer.flipX = false;
        }
    }

    public void TurnIfAngleInCertainRange(float angle)
    {
        // Угол в 90 градусов означает,
        // что объект столкнулся именно со стеной
        if (Mathf.Abs(angle) == 90f)
        {
            birdMovement.FlipMovementDirection();
            flipImageX();
        }
    }

    private void flipImageX()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}