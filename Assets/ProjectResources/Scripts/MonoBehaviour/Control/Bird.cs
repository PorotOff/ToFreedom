using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRigidbody;

    [SerializeField] private float waveForce = 2f;
    [SerializeField] private float movementSpeed = 2f;

    private SpriteRenderer spriteRenderer;

    private BirdWave birdWave;
    private BirdMovement birdMovement;
    private UTurn uTurn;

    private void Awake()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        birdWave = new BirdWave(birdRigidbody, waveForce);
        birdMovement = new BirdMovement(birdRigidbody, movementSpeed);
        uTurn = new UTurn(birdMovement, spriteRenderer);
    }

    private void OnEnable()
    {
        TouchInputNotify.OnTouchedScreen += birdWave.Flap;
    }
    private void OnDisable()
    {
        TouchInputNotify.OnTouchedScreen -= birdWave.Flap;
    }

    private void FixedUpdate()
    {
        birdMovement.Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float contactAngle = getContactAngle(other.contacts[other.contactCount - 1]);
        
        uTurn.TurnIfAngleInCertainRange(contactAngle);
    }

    private float getContactAngle(ContactPoint2D contact)
    {
        Vector2 normal = contact.normal;

        return Mathf.Atan2(normal.x, normal.y) * Mathf.Rad2Deg;
    }
}