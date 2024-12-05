public class StayBirdMovementState : IBirdMovementState
{
    public void Stay(BirdMovement birdMovement)
    {
        birdMovement.FlipStartDirection();
        birdMovement.SetActiveSimulatedRigidbody(false);
    }

    public void Move(BirdMovement birdMovement) { }
}