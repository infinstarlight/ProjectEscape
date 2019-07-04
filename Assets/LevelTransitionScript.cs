using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTransitionScript : MonoBehaviour
{
    public string NextLevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            SceneManager.LoadScene(NextLevelToLoad);
            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByName(NextLevelToLoad));

        }
    }
}
