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
        Debug.Log(generator.gameObject.name);
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit the loader");
        if (loaded == false)
        {
            generator.LoadNewChunk();
            loaded = true;
        }
    }
}
