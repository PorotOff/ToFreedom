using System;
using UnityEngine;

public class BirdMovementModel
{
    private Rigidbody2D birdRigidbody { get; set; }

    private float speed;
    private float Speed
    {
        get { return speed; }
        set
        {
            speed = value;

            if (speed <= 0)
            {
                speed = 0;

                Debug.Log("Скорость равна нулю, потому что изменяющее значение оказалось слишком большим");
            }
        }
    }
    private Vector2 movementDirection = Vector2.right;

    public BirdMovementModel(Rigidbody2D birdRigidbody, float speed)
    {
        this.birdRigidbody = birdRigidbody;
        Speed = speed;
    }

    public void Move()
    {
        Vector2 currentVelocity = birdRigidbody.linearVelocity;
        Vector2 newVelocity = movementDirection * Speed;
        newVelocity.y = currentVelocity.y;

        birdRigidbody.linearVelocity = newVelocity;
    }

    public void FlipMovementDirection()
    {
        movementDirection = movementDirection * -1;
    }

    public void AddSpeed(float speed)
    {
        if (speed <= 0)
        {
            throw new Exception("Значение не может быть отрицательное или ноль, чтобы добавить скорость");
        }

        Speed += speed;
    }
    public void ReduceSpeed(float speed)
    {
        if (speed >= 0)
        {
            throw new Exception("Значение не может быть положительное или ноль, чтобы убавить скорость");
        }

        Speed -= speed;
    }
}