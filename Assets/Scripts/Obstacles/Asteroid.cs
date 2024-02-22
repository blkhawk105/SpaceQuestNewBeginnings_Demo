using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : FlyingObstacle
{
    private GameManager gameManager;

    /// <summary>
    /// The width of the asteroid object
    /// </summary>
    private float asteroidWidth;
    /// <summary>
    /// The height of the asteroid object
    /// </summary>
    private float asteroidHeight;
    /// <summary>
    /// The amount of padding added when calculating where the asteroid moves on screen
    /// </summary>
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        Speed = 5;
        
        // Set the player's ship width and height
        asteroidWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        asteroidHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        
        
        
        float randomY = Random.Range(-gameManager.ScreenBounds.y + (asteroidHeight * 2), gameManager.ScreenBounds.y - (asteroidHeight * 2));
        transform.position = new(gameManager.ScreenBounds.x + (asteroidWidth * 4), randomY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    /// <summary>
    /// Move the Asteroid across the screen
    /// </summary>
    private void Move()
    {
        // Move the player forward and backward
        transform.Translate(Time.deltaTime * Speed * Vector3.left);

        if(transform.position.x < -gameManager.ScreenBounds.x - (asteroidWidth * 4))
        {
            DestroyObject();
        }
    }

    protected override void DestroyObject()
    {
        base.DestroyObject();

        gameManager.AsteroidSpawnRate = Random.Range(3.0f, 8.0f);
        gameManager.ShouldSpawnAsteroid = true;
    }
}
