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

    public float speed;
    public float jumpHeight;
    public float groundAccuracy;

    public bool alive = true;

    public float score;

    [SerializeField]
    bool isOnGround = true;
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
        if (alive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
            {
                rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") + speed, jumpHeight);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") + speed, rigidbody2D.velocity.y);
            }
            UpdateScore();
        }
    }
    void CheckGround()
    {
        if (rigidbody2D.velocity.y > groundAccuracy || rigidbody2D.velocity.y < -groundAccuracy)
        {
            isOnGround = false;
        }
        else
        {
            isOnGround = true;
        }
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
        alive = false;
    }
}
