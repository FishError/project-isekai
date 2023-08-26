using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PhysicsEntity : Entity
{
    public float gravity { get;  protected set; } = 9.81f;

    public Vector2 tempVelocity;
    public List<Vector2> velocities;
    public bool grounded;

    public Rigidbody2D rb { get; protected set; }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocities = new List<Vector2>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        CheckGrounded();
        ApplyGravity();
        CalculateNetVelocity();
    }

    private void CalculateNetVelocity()
    {
        tempVelocity = rb.velocity;
        for (int i = 0; i < velocities.Count; i++)
        {
            tempVelocity += velocities[i];
        }
        velocities.Clear();
        rb.velocity = tempVelocity;
    }

    private void CheckGrounded()
    {
        float distance = Mathf.Abs(rb.velocity.y) * Time.fixedDeltaTime;
        Bounds bounds = GetComponentInChildren<BoxCollider2D>().bounds;
        Vector3 raySpacing = new Vector3(bounds.size.x / 2, 0);
        for (int i = 0; i < 3; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(bounds.min + raySpacing * i, Vector2.down, (distance < 0.05f) ? 0.05f : distance);
            if (hit.collider != null)
            {
                float angle = Vector2.Angle(Vector2.down, hit.normal);

                if (180 - angle < 31)
                    grounded = true;

                return;
            }
            grounded = false;
        }
    }

    private void ApplyGravity()
    {
        if (!grounded)
            velocities.Add(gravity * Time.fixedDeltaTime * Vector2.down);
    }

    public void AdjustGravity(float updatedGravity)
    {
        gravity = updatedGravity;
    }

    public void ResetGravity()
    {
        gravity = 9.81f;
    }
}
