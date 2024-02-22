using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : FlyingObstacle
{
    /// <summary>
    /// The edge of the playable screen
    /// </summary>
    private Vector2 screenBounds;
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
        Speed = 5;

        // Set the visible screen area
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        // Set the player's ship width and height
        asteroidWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        asteroidHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        
        
        
        float randomY = Random.Range(-screenBounds.y + (asteroidHeight * 2), screenBounds.y - (asteroidHeight * 2));
        transform.position = new(screenBounds.x + (asteroidWidth * 4), randomY, transform.position.z);
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

        if(transform.position.x < -screenBounds.x - (asteroidWidth * 4))
        {
            Destroy(gameObject);
        }
    }
}
