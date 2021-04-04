using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float jumpForce = 100;
    public float iceJumpForceDivider = 2;
    public float moveSpeed = 10;
    public float minTimeBetweenJumps = 1;

    private Rigidbody2D rigidbody;
    private bool isGrounded = false;
    private bool isOnIce = false;
    private float lastJumpTime = 0;
    private LifeSystem lifeSystem;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        lifeSystem = GetComponent<LifeSystem>();
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Moveleft();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.Space) && (isGrounded || isOnIce))
        {
            if (lastJumpTime + minTimeBetweenJumps < Time.time)
            {
                lastJumpTime = Time.time;
                Jump();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
        if (collision.collider.tag == "Ice")
            isOnIce = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
        if(collision.collider.tag == "Ice")
            isOnIce = true;
        if (collision.collider.tag == "Spike")
            Respawn();
    }

    private void Moveleft()
    {
        rigidbody.AddForce(new Vector2(-moveSpeed * rigidbody.mass, 0));
    }

    private void MoveRight()
    {
        rigidbody.AddForce(new Vector2(moveSpeed * rigidbody.mass, 0));
    }
    private void Jump()
    {
        float actualJumpForce = jumpForce;
        if (isOnIce)
            actualJumpForce /= 2;
        rigidbody.AddForce(new Vector2(0, actualJumpForce * rigidbody.mass));
    }
    private void Respawn()
    {
        gameObject.transform.position = startPosition;
        lifeSystem.Die();
    }
}
