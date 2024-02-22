using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneManager : MonoBehaviour
{
    public GameObject asteroid;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
       // Get a reference to the game manager
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

       if (gameManager.ShouldSpawnAsteroid)
        {
            StartCoroutine(SpawnAsteroid());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAsteroid()
    {
        while(gameManager.IsGameActive)
        {
            yield return new WaitForSeconds(gameManager.AsteroidSpawnRate);
            
            gameManager.ShouldSpawnAsteroid = false;

            Instantiate(asteroid);
            
            /*
            For a random version of an asteroid
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            */
        }
    }
}
