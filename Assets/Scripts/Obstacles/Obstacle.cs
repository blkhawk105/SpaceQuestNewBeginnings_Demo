using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// Can this object be destroyed
    /// </summary>
    [SerializeField] protected bool IsDestroyable = true;

    /// <summary>
    /// The amount of damage an object can take before it is destroyed
    /// </summary>
    [SerializeField] protected int Strength = 10;
    

    protected void ObjectHit(int damageTaken)
    {
        if (this.IsDestroyable)
        {
            Strength -= damageTaken;
        }

        if (Strength <= 0)
        {
            DestroyObject();
        }
    }

    protected virtual void DestroyObject()
    {
        Destroy(gameObject);
    }

    
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
