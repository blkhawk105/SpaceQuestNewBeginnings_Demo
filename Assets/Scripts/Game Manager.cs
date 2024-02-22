using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive { get; private set; }
    
    public bool ShouldSpawnAsteroid = false;
    public float AsteroidSpawnRate = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        IsGameActive = true;
        ShouldSpawnAsteroid = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
