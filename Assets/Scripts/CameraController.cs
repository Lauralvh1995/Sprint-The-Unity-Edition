using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Player playerInFirst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerInFirst.transform.position.x + 3, -2, -15);
    }
    public void SetPlayerInFirst(Player p)
    {
        playerInFirst = p;
    }
}
