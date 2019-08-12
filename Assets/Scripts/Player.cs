using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerColor color;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public GameObject startPoint;
    public LayerMask groundMask;

    public float speed;
    public float jumpHeight;
    public float jumpShort;
    public float groundAccuracy;

    public bool alive = true;

    public float score;

    public string inputAxis;
    public KeyCode jumpButton;

    [SerializeField]
    bool isOnGround = true;
    bool jump = false;
    bool jumpCancel = false;
    [SerializeField]
    Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        switch (color)
        {
            case PlayerColor.Green:
                inputAxis = "Horizontal1";
                jumpButton = KeyCode.W;
                break;
            case PlayerColor.Blue:
                inputAxis = "Horizontal2";
                jumpButton = KeyCode.G;
                break;
            case PlayerColor.Red:
                inputAxis = "Horizontal3";
                jumpButton = KeyCode.I;
                break;
            case PlayerColor.Purple:
                inputAxis = "Horizontal4";
                jumpButton = KeyCode.UpArrow;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rigidbody2D.velocity;
        CheckGround();
        if(alive)
        {
            if (Input.GetKeyDown(jumpButton) && isOnGround)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }

            if (Input.GetKeyUp(jumpButton) && !isOnGround)     // Player stops pressing the button
            {
                jumpCancel = true;
            }
        }
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxis(inputAxis) + speed, rigidbody2D.velocity.y);
        if (jump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
        }
            
        if (jumpCancel)
        {
            if (rigidbody2D.velocity.y > jumpShort)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpShort);
            }
            jumpCancel = false;
        }
        if(!alive)
        {
            rigidbody2D.velocity = new Vector2(0, -9.81f);
        }
        else
        {
            UpdateScore();
        }
    }
    void CheckGround()
    {
        isOnGround = Physics2D.OverlapCircle(transform.position, 0.5f + groundAccuracy, groundMask);
    }

    void UpdateScore()
    {
        score = Mathf.FloorToInt(transform.position.x - startPoint.transform.position.x);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void Die()
    {
        isOnGround = true;
        alive = false;
        animator.SetBool("Dead", true);
    }
}
