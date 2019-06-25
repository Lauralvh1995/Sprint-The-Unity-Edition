using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MapEntity
{
    public LevelGenerator generator;
    bool loaded = false;
    private void Start()
    {
        generator = FindObjectOfType<LevelGenerator>();
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoundingBox")
        {
            Debug.Log("Hit the loader");
            if (loaded == false)
            {
                generator.LoadNewChunk();
                loaded = true;
            }
        }
    }
}
