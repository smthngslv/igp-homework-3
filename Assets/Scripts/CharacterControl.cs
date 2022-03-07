using System;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed = 1.0f;
    public float directionSmoothness = 0.95f;
    
    void Update()
    {
        // Current non-smoothed direction vector.
        Vector3 targetDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")
        );
        
        // If no button pressed then do not change direction.
        if (targetDirection.magnitude != 0)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation, Quaternion.LookRotation(targetDirection), 1.0f - directionSmoothness
            );
        }
        
        // Use standard smoothed input axes as velocity.
        float velocity = Math.Max(Math.Abs(Input.GetAxis("Horizontal")), Math.Abs(Input.GetAxis("Vertical")));

        // Move.
        transform.position += transform.forward * velocity * speed;
    }
}
