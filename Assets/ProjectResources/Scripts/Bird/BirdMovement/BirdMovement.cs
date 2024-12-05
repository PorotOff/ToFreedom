using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private BirdMovementModel birdMovementModel;

    private Rigidbody2D birdRigidbody;

    private TransformFlipping transformFlipping;

    [Header("Movement settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isRightStartDirection = true;

    private IBirdMovementState birdMovementState;

    private void Awake()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();

        birdMovementModel = new BirdMovementModel(birdRigidbody, movementSpeed);

        transformFlipping = new TransformFlipping(gameObject.transform);

        birdMovementState = new StayBirdMovementState();
    }

    private void OnEnable()
    {
        StartGameNotify.OnGameStarted += SetMoveBirdState;
    }
    private void OnDisable()
    {
        StartGameNotify.OnGameStarted -= SetMoveBirdState;
    }

    private void Start()
    {
        birdMovementState.Stay(this);
    }

    private void FixedUpdate()
    {
        birdMovementState.Move(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        FlipDirectionAfterCollision(other);
    }

    public void Move()
    {
        birdMovementModel.Move();
    }

    #region Bird FLIPping
    public void FlipStartDirection()
    {
        if (!isRightStartDirection)
        {
            FlipDirection();
        }
    }
    private void FlipDirectionAfterCollision(Collision2D collision)
    {
        ContactPoint2D currentContact = collision.contacts[collision.contactCount - 1];
        var withWallCollisionChecking = new WithWallCollisionChecking(currentContact);

        if (withWallCollisionChecking.IsWall())
        {
            FlipDirection();

            Debug.Log($"On collision with: {collision.gameObject.name} flip");
        }
    }
    private void FlipDirection()
    {
        birdMovementModel.FlipMovementDirection();
        transformFlipping.FlipByX();
    }
    #endregion

    private void SetMoveBirdState()
    {
        birdMovementState = new MoveBirdMovementState();
        SetActiveSimulatedRigidbody(true);
    }

    public void SetActiveSimulatedRigidbody(bool isActive)
    {
        birdRigidbody.simulated = isActive;
    }
}