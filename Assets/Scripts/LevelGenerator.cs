using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> chunkDatabase = new List<GameObject>();
    public List<GameObject> chunks = new List<GameObject>();
    public int chunkWidth;

    public GameObject startChunk;
    public GameObject startPoint;
    static int offset;
    System.Random random = new System.Random();
    // Start is called before the first frame update
    public void Start()
    {
        chunks.Add(startChunk);
        offset = offset + chunkWidth;
    }
    public void LoadNewChunk()
    {
        int index = random.Next(0, chunkDatabase.Count);
        Vector3 newPos = new Vector3(startPoint.transform.position.x + offset, 0);
        GameObject newChunk = Instantiate(chunkDatabase[index], newPos, transform.rotation);
        chunks.Add(newChunk);
        offset = offset + chunkWidth;
        if(chunks.Count > 2)
        {
            Destroy(chunks[0].gameObject);
            chunks.RemoveAt(0);
        }
    }
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
        SceneManager.UnloadSceneAsync("Game");
    }
}
