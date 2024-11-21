using UnityEngine;

public class WithWallCollisionChecking
{
    private ContactPoint2D contact;

    public WithWallCollisionChecking(ContactPoint2D contact)
    {
        this.contact = contact;
    }

    public bool IsWall()
    {
        float contactAngle = GetContactAngle();

        return Mathf.Abs(contactAngle) == 90f;
    }
    
    private float GetContactAngle()
    {
        Vector2 normal = contact.normal;

        return Mathf.Atan2(normal.x, normal.y) * Mathf.Rad2Deg;
    }
}