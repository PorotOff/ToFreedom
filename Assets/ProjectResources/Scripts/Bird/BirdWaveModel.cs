using UnityEngine;

public class BirdWaveModel
{
    private Rigidbody2D birdRigidbody;
    private float waveForce;

    public BirdWaveModel(Rigidbody2D birdRigidbody, float waveForce)
    {
        this.birdRigidbody = birdRigidbody;
        this.waveForce = waveForce;
    }

    public void Flap()
    {
        // Для того, чтобы птица не накапливала всё большую скорость при множестве кликов,
        // её нужно обнулить. Тогда взмах будет каждый раз одинаковый
        birdRigidbody.linearVelocity = new Vector2(birdRigidbody.linearVelocityX, 0f);

        birdRigidbody.AddForce(Vector2.up * waveForce, ForceMode2D.Impulse);
    }
}