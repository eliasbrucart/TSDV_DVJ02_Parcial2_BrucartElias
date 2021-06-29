using System;
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
    [SerializeField] private float rotationSpeed;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private LayerMask mountain;
    [SerializeField] private LayerMask platform;

    public Rigidbody2D rb;

    private float initialFuel;
    private bool isMoving;
    private bool isAlive;
    private bool activeRB = false;
    private float gravityScale; //hacer
    private float altitude; //hacer
    private float originalGravity = 1.0f;
    private float angle = 0.0f;

    private Vector2 initialPos;
    private Vector2 rbForce;

    public static event Action PlayerDie;

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
        BoostPrepellant();
    }

    private void BoostPrepellant()
    {
        if (activeRB)
            rb.AddRelativeForce(rbForce);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle += rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
            if (!particle.isEmitting)
                particle.Play();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle -= rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            if (!particle.isEmitting)
                particle.Play();
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            activeRB = true;
            isMoving = true;
            if (!particle.isEmitting)
                particle.Play();
            fuel -= (fuelCost * Time.deltaTime);
        }
        else
        {
            isMoving = false;
            activeRB = false;
        }
        if (!isMoving)
            particle.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            //llamar evento de landed
            isAlive = false;
        }
        if (collision.gameObject.CompareTag("Platform2"))
        {
            //llamar evento de landed
            isAlive = false;
        }
        if (collision.gameObject.CompareTag("Platform4"))
        {
            //llamar evento de landed
            isAlive = false;
        }
        if (collision.gameObject.CompareTag("Platform5"))
        {
            //llamar evento de landed
            isAlive = false;
        }
        if (collision.gameObject.CompareTag("MountainMoon"))
        {
            isAlive = false;
            fuel = 0.0f;
            PlayerDie?.Invoke();
        }
    }
}
