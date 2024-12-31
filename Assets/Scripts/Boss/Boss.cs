using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Actors
{
    public int damage;
    public Transform player;
    [SerializeField] private PlayerDistance dist;
    private bool attackPhase;
    private bool down;
    private float hoverHeight;
    private float attackTime;
    private float downTime;
    public GameObject bulletPrefab;
    public Transform FiringPoint;
    public float fireRate;
    private float timeToFire;
    private float jumpCooldownTime = 5f;
    private float goDownTime = 3f;

    public virtual void Start()
    {
        base.Start();
        rb.gravityScale = 3.5f;
        GetTarget();
        attackPhase = false;
        hoverHeight = 0.6f;
        FiringPoint = this.transform;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            dist = playerObject.GetComponent<PlayerDistance>(); // Assign the player’s transform
        }
        base.setHealth(dist.GetTotalDistanceMoved() / 10000);
    }

    private void Update()
    {
        Debug.Log(base.getHealth());
        if (!attackPhase)
        {
            attackTime -= Time.deltaTime;

            if (attackTime <= 0f)
            {
                // Jump phase triggered, reset timer
                attackTime = jumpCooldownTime; // Reset timer for next jump phase
                attackPhase = true;
            }
        }

        if (attackPhase)
        {
            rb.gravityScale = 0f;
            Vector2 currentPosition = transform.position;
            transform.position = new Vector2(currentPosition.x, hoverHeight);
            MoveTowardPlayer();
        }

        // ShootAtPlayer();
    }

    private void MoveTowardPlayer()
    {
        if (player != null)
        {
            Vector2 currentPosition = transform.position;
            float newX = Mathf.MoveTowards(currentPosition.x, player.position.x, speed * Time.deltaTime);
            transform.position = new Vector2(newX, currentPosition.y);
            // transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (!down)
        {
            downTime -= Time.deltaTime;

            if (downTime <= 0f)
            {
                // Jump phase triggered, reset timer
                down = true;
                downTime = goDownTime; // Reset timer for next jump phase
                attackPhase = false;
            }
        }

        if (down)
        {
            rb.gravityScale = 10f;
            down = false;
        }
    }

    private void ShootAtPlayer()
    {
        if (timeToFire <= 0f)
        {
            Instantiate(bulletPrefab, FiringPoint.position, FiringPoint.rotation);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void GetTarget()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (attackPhase)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.takeDamage(damage);
                }
            }
        }
    }
}