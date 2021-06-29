using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity;
    [SerializeField] private float moonGravity;
    [SerializeField] private float force;
    [SerializeField] private float fuel;
    [SerializeField] private float fuelCost;
    [SerializeField] private float speed = 2.0f;

    public Rigidbody2D rb;

    private float initialFuel;
    private bool isMoving;
    private bool isAlive;
    private bool activeRB = false;
    private float gravityScale;
    float altitude;
    float originalGravity = 1.0f;

    private Vector2 initialPos;
    private Vector2 rbForce;

    void Start()
    {
        isAlive = true;
        isMoving = true;
        initialFuel = fuel;
        initialPos = new Vector2(transform.position.x, transform.position.y);
        rb.GetComponent<Rigidbody2D>();
        float newGravity = (moonGravity * originalGravity) / gravity;
        rb.gravityScale = newGravity;
    }

    void Update()
    {
        if (!isAlive)
            return;
        rbForce = new Vector2(0, force);
        Move();
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
        }
        if (rb.velocity.magnitude < -speed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, -speed);
        }
    }

    private void FixedUpdate()
    {
        if (!isAlive)
            return;
        if(activeRB)
            rb.AddRelativeForce(rbForce);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            activeRB = true;
            isMoving = true;
            fuel -= (fuelCost * Time.deltaTime);
        }
        else
        {
            isMoving = false;
            activeRB = false;
        }
    }
}
