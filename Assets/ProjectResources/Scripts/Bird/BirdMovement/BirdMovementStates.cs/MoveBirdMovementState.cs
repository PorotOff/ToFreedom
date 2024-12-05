public class MoveBirdMovementState : IBirdMovementState
{
    public void Stay(BirdMovement birdMovement) { }

    public void Move(BirdMovement birdMovement)
    {
        birdMovement.Move();
    }
}