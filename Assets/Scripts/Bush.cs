using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MapEntity
{
    [Range(0,0.5f)]
    public float slowFactor;

    float speedMemory;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == true)
        {
            speedMemory = collision.GetComponent<Player>().GetSpeed();
            collision.GetComponent<Player>().SetSpeed(speedMemory * slowFactor);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Player>().SetSpeed(speedMemory);
    }
}
