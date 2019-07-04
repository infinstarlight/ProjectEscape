using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTransitionScript : MonoBehaviour
{
    public string NextLevelToLoad;
    private string PreviousLevel;
    // Start is called before the first frame update
    void Start()
    {
        PreviousLevel = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            SceneManager.LoadScene(NextLevelToLoad,LoadSceneMode.Additive);
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            SceneManager.UnloadSceneAsync(PreviousLevel);
        }
            
    }
}
