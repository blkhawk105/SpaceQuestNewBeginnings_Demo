using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive { get; private set; }
    
    public bool ShouldSpawnAsteroid = false;
    public float AsteroidSpawnRate = 5;

    /// <summary>
    /// The edge of the playable screen
    /// </summary>
    public Vector2 ScreenBounds;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the visible screen area
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        IsGameActive = true;
        ShouldSpawnAsteroid = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
