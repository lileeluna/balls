using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private int jumped;
    private bool hasDoubleJump;
    private BoxCollider2D boxCollider;
    private Animator animate;
    private SpriteRenderer render;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animate = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        hasDoubleJump = false;
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetAxis("Horizontal") < 0)
        {

        }
        if (canJump())
            Jump();
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        jumped++;
    }

    public void setDouble(bool dj)
    {
        hasDoubleJump = dj;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        if (raycastHit.collider != null)
        {
            jumped = 0;
            return true;
        }

        return false;
    }

    private bool canJump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded() || (jumped == 1 && hasDoubleJump)))
        {
            if (jumped == 1)
            {
                setDouble(false);
            }
            return true;
        }
        return false;
    }
}