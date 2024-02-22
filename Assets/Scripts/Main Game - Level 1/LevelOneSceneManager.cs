using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneManager : MonoBehaviour
{
    public GameObject asteroid;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(asteroid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
