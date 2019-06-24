using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MapEntity
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() == true)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3);
        }
    }
}
