using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    private Transform playerSpawnPoint;
    private GameObject playerGO;
    public string LevelToLoad;

    private void Awake()
    {
        playerSpawnPoint = gameObject.transform;
        playerGO = Resources.Load<GameObject>("Prefabs/Player/PlayerCharacter");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!SceneManager.GetSceneByName("PersistentLevel").isLoaded)
        {
            SceneManager.LoadScene("PersistentLevel", LoadSceneMode.Additive);
        }
        if (playerGO)
        {
            Instantiate(playerGO, playerSpawnPoint);
          // SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Additive);
        }
    }
}
