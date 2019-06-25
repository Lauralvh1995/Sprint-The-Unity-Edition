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
    public GameObject ScoreUI;
    public GameObject startPoint;
    public LayerMask groundMask;

    public float speed;
    public float jumpHeight;
    public float jumpShort;
    public float groundAccuracy;

    public bool alive = true;

    public float score;

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

                break;
            case PlayerColor.Blue:

                break;
            case PlayerColor.Purple:

                break;
            case PlayerColor.Red:

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
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                jump = true;
            }
            else
            {
                jump = false;
            }

            if (Input.GetKeyUp(KeyCode.Space) && !isOnGround)     // Player stops pressing the button
                jumpCancel = true;
            UpdateScore();
        }
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") + speed, rigidbody2D.velocity.y);
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
    }
    void CheckGround()
    {
        isOnGround = Physics2D.OverlapCircle(transform.position, 0.5f + groundAccuracy, groundMask);
    }

    void UpdateScore()
    {
        score = Mathf.FloorToInt(transform.position.x - startPoint.transform.position.x);
        ScoreUI.GetComponent<Text>().text = score.ToString();
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
