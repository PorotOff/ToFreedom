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
    private Vector2 movementDirection { get; set; }

    public BirdMovementModel(Rigidbody2D birdRigidbody, float speed, Vector2 startDirection)
    {
        this.birdRigidbody = birdRigidbody;
        Speed = speed;

        if (startDirection.y != 0f || (startDirection.x != 1f && startDirection.x != -1f))
        {
            movementDirection = Vector2.right;

            throw new Exception($"startDirection задан не правильно. " +
            $"Значение X должно быть либо 1, либо -1, а оно {movementDirection.x}. " +
            $"Значение Y должно быть 0, а оно {movementDirection.y}. " +
            $"Сейчас автоматически установлено: {movementDirection}");
        }
        
        movementDirection = startDirection;
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

        this.Speed += speed;
    }
    public void ReduceSpeed(float speed)
    {
        if (speed >= 0)
        {
            throw new Exception("Значение не может быть положительное или ноль, чтобы убавить скорость");
        }

        this.Speed -= speed;
    }
}