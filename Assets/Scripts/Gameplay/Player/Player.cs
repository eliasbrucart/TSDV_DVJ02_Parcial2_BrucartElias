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
    [SerializeField] private float rayDistance;

    public Rigidbody2D rb;

    private float initialFuel;
    private bool isMoving;
    private bool isAlive;
    private bool activeRB;
   // private float gravityScale;
    private float altitude;
    private float originalGravity = 1.0f;
    private float angle = 0.0f;
    private float initialAngularDrag = 0.05f;

    private Vector2 initialPos;
    private Vector2 rbForce;

    public static event Action PlayerDie;
    public static event Action PlayerLanded;
    public static event Action PlayerLanded2;
    public static event Action PlayerLanded4;
    public static event Action PlayerLanded5;
    public static event Action PlayerCamZoom;
    public static event Action PlayerCamZoomOut;
    public static event Action outOfFuel;

    void Start()
    {
        isAlive = true;
        isMoving = true;
        initialFuel = fuel;
        initialPos = new Vector2(transform.position.x, transform.position.y);
        activeRB = false;
        rb.GetComponent<Rigidbody2D>();
        float newGravity = (moonGravity * originalGravity) / gravity;
        rb.gravityScale = newGravity;
        UICrash.RespawnPlayer += Respawn;
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
        if (fuel <= 0.0f)
        {
            outOfFuel?.Invoke();
            fuel = initialFuel;
        }
    }

    private void FixedUpdate()
    {
        if (!isAlive)
            return;
        BoostPrepellant();
        CalculateAltitude();
        ZoomCamToPlayer();
    }

    private void BoostPrepellant()
    {
        if (activeRB)
            rb.AddRelativeForce(rbForce);
    }

    private void CalculateAltitude()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 100, mountain);
        if ((hit.collider.CompareTag("MountainMoon")) || (hit.collider.CompareTag("Platform1")) || (hit.collider.CompareTag("Platform2")) || (hit.collider.CompareTag("Platform4")) || (hit.collider.CompareTag("Platform5")))
            altitude = Mathf.Abs(hit.point.y - transform.position.y);
    }

    private void ZoomCamToPlayer()
    {
        if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, rayDistance, mountain) || Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, rayDistance, platform))
            PlayerCamZoom?.Invoke();
        else
            PlayerCamZoomOut?.Invoke();
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
        StopParticlePlayer();
    }

    void StopParticlePlayer()
    {
        if (!isAlive || !isMoving)
            particle.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform1"))
        {
            PlayerLanded?.Invoke();
            isAlive = false;
            isMoving = false;
            StopParticlePlayer();
        }
        if (collision.gameObject.CompareTag("Platform2"))
        {
            PlayerLanded2?.Invoke();
            isAlive = false;
            isMoving = false;
            StopParticlePlayer();
        }
        if (collision.gameObject.CompareTag("Platform4"))
        {
            PlayerLanded4?.Invoke();
            isAlive = false;
            isMoving = false;
            StopParticlePlayer();
        }
        if (collision.gameObject.CompareTag("Platform5"))
        {
            PlayerLanded5?.Invoke();
            isAlive = false;
            isMoving = false;
            StopParticlePlayer();
        }
        if (collision.gameObject.CompareTag("MountainMoon"))
        {
            isAlive = false;
            isMoving = false;
            StopParticlePlayer();
            PlayerDie?.Invoke();
        }
    }

    public void Respawn()
    {
        transform.position = new Vector3(initialPos.x, initialPos.y, 0);
        isAlive = true;
        isMoving = true;
        activeRB = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.angularDrag = initialAngularDrag;
        transform.rotation = Quaternion.identity;
        angle = 0;
    }

    public float GetFuel()
    {
        return fuel;
    }

    public Rigidbody2D GetRB()
    {
        return rb;
    }

    public float GetAltitude()
    {
        return altitude;
    }

    private void OnDisable()
    {
        UICrash.RespawnPlayer -= Respawn;
    }
}
