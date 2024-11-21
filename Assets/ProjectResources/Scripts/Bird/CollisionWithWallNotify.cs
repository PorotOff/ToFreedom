using System;
using UnityEngine;

public class CollisionWithWallNotify
{
    public event Action OnCollided;

    public void Notify(ContactPoint2D contact)
    {
        float contactAngle = GetContactAngle(contact);

        if (IsWall(contactAngle))
        {
            OnCollided?.Invoke();
        }
    }
    private bool IsWall(float angle)
    {
        return Mathf.Abs(angle) == 90f;
    }
    private float GetContactAngle(ContactPoint2D contact)
    {
        Vector2 normal = contact.normal;

        return Mathf.Atan2(normal.x, normal.y) * Mathf.Rad2Deg;
    }
}