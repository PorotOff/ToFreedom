using UnityEngine;

public class BirdMovement
{
    private Rigidbody2D birdRigidbody { get; set; }

    private float movementSpeed { get; set; }
    private Vector2 movementDirection { get; set; }

    public BirdMovement(Rigidbody2D birdRigidbody, float movementSpeed)
    {
        this.birdRigidbody = birdRigidbody;

        this.movementSpeed = movementSpeed;
        movementDirection = Vector2.right;
    }
    public BirdMovement(Rigidbody2D birdRigidbody, float movementSpeed, Vector2 startMovementDirection)
    {
        this.birdRigidbody = birdRigidbody;

        this.movementSpeed = movementSpeed;
        movementDirection = startMovementDirection;
    }

    public void Move()
    {
        Vector2 currentVelocity = birdRigidbody.linearVelocity;
        Vector2 newVelocity = movementDirection * movementSpeed;
        newVelocity.y = currentVelocity.y;

        birdRigidbody.linearVelocity = newVelocity;
    }

    public void FlipMovementDirection()
    {
        movementDirection = movementDirection * -1;
    }
    public bool IsRightMovement()
    {
        return movementDirection == Vector2.right;
    }
}