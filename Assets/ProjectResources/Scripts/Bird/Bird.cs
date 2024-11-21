using UnityEngine;

public class Bird : MonoBehaviour, IFlappable
{
    private BirdMovementModel birdMovementModel;
    private BirdWaveModel birdWaveModel;
    private IFlappable birdWaveView;
    private BirdXFlippingModel birdXFlippingModel;

    private Rigidbody2D birdRigidbody;

    [Header("Movement settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float waveForce;
    [SerializeField] private bool isRightStartDirection = true;

    [Header("Spite settings")]
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite unflap;
    [SerializeField] private Sprite flap;
    [SerializeField] private Sprite squeekFlap;

    private void Awake()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        birdMovementModel = new BirdMovementModel(birdRigidbody, movementSpeed);
        birdWaveModel = new BirdWaveModel(birdRigidbody, waveForce);
        birdWaveView = new BirdWaveView(spriteRenderer, unflap, flap, squeekFlap);
        birdXFlippingModel = new BirdXFlippingModel(gameObject.transform);
    }

    private void Start()
    {
        FlipStartDirection();
        Flap();
    }

    private void OnEnable()
    {
        FlapInputNotify.OnFlaped += Flap;
        FlapInputNotify.OnSqueekFlaped += SqueekFlap;
        FlapInputNotify.OnUnflapped += Unflap;
    }
    private void OnDisable()
    {
        FlapInputNotify.OnFlaped -= Flap;
        FlapInputNotify.OnSqueekFlaped -= SqueekFlap;
        FlapInputNotify.OnUnflapped -= Unflap;
    }

    private void FixedUpdate()
    {
        birdMovementModel.Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D currentContact = other.contacts[other.contactCount - 1];
        var withWallCollisionChecking = new WithWallCollisionChecking(currentContact);

        if (withWallCollisionChecking.IsWall())
        {
            birdXFlippingModel.FlipByX();
            birdMovementModel.FlipMovementDirection();
        }
    }

    public void Flap()
    {
        birdWaveModel.Flap();
        birdWaveView.Flap();
    }
    public void SqueekFlap()
    {
        birdWaveModel.Flap();
        birdWaveView.SqueekFlap();

    }
    public void Unflap()
    {
        birdWaveView.Unflap();
    }

    private void FlipStartDirection()
    {
        if (!isRightStartDirection)
        {
            birdMovementModel.FlipMovementDirection();
            birdXFlippingModel.FlipByX();
        }
    }
}