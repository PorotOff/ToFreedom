using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdWave : MonoBehaviour, IFlappable
{
    private BirdWaveModel birdWaveModel;
    private IFlappable birdWaveView;

    private Rigidbody2D birdRigidbody;

    [Header("Wave settings")]
    [SerializeField] private float waveForce;

    [Header("Sprite settings")]
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite unflap;
    [SerializeField] private Sprite flap;
    [SerializeField] private Sprite squeekFlap;

    private void Awake()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        birdWaveModel = new BirdWaveModel(birdRigidbody, waveForce);
        birdWaveView = new BirdWaveView(spriteRenderer, unflap, flap, squeekFlap);
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
}