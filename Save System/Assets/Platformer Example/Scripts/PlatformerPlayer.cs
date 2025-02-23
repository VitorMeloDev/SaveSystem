using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;

    public bool canMove;

    public LayerMask whatIsGround;
    public Transform groundCheckPoint;

    private bool isGrounded;

    public Animator anim;

    public SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (canMove)
        {
            theRB.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.linearVelocity.y);

            if(theRB.linearVelocity.x != 0f)
            {
                theSR.flipX = theRB.linearVelocity.x > 0f;
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
            }
        } else
        {
            theRB.linearVelocity = new Vector2(0f, theRB.linearVelocity.y);
        }

        anim.SetFloat("speed", Mathf.Abs(theRB.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
}
