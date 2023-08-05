using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PhysicsEntity : Entity
{
    public float gravity = 9.81f;

    public Vector3 velocity;
    public Vector3 tempVelocity;
    public List<Vector3> velocities;
    public bool grounded;

    public Rigidbody rb { get; protected set; }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocities = new List<Vector3>();
    }

    protected virtual void FixedUpdate()
    {
        if (!rb.isKinematic)
        {
            CheckGrounded();
            ApplyGravity();
            CalculateNetVelocity();
            rb.velocity = tempVelocity;
        }
    }

    private void CalculateNetVelocity()
    {
        tempVelocity = rb.velocity;
        for (int i = 0; i < velocities.Count; i++)
        {
            tempVelocity += velocities[i];
        }
        velocities.Clear();
    }

    private void CheckGrounded()
    {
        float distance = Mathf.Abs(rb.velocity.y) * Time.fixedDeltaTime;
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, (distance < 0.005f) ? 0.005f : distance))
        {
            float angle = Vector3.Angle(Vector3.down, hit.normal);

            if (180 - angle < 31)
                grounded = true;

            return;
        }
        grounded = false;
    }

    private void ApplyGravity()
    {
        if (!grounded)
            velocities.Add(gravity * Time.fixedDeltaTime * Vector3.down);
    }
}
