using UnityEngine;

public class BirdWaveView : IFlappable
{
    private SpriteRenderer spriteRenderer;

    private Sprite unflap { get; set; }
    private Sprite flap { get; set; }
    private Sprite squeekFlap { get; set; }
    
    public BirdWaveView(SpriteRenderer spriteRenderer, Sprite unflap, Sprite flap, Sprite squeekFlap)
    {
        this.spriteRenderer = spriteRenderer;

        this.unflap = unflap;
        this.flap = flap;
        this.squeekFlap = squeekFlap;
    }

    public void Flap()
    {
        spriteRenderer.sprite = flap;
    }
    public void SqueekFlap()
    {
        spriteRenderer.sprite = squeekFlap;
    }
    public void Unflap()
    {
        spriteRenderer.sprite = unflap;
    }
}
