using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MapEntity
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() == true)
        {
            collision.GetComponent<Player>().Die();
        }
    }
}
