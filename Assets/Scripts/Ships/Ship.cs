using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    [SerializeField] protected int HullStrength = 0;
    [SerializeField] protected int ShieldLevel = 0;

    [SerializeField] protected int PrimaryGunPower = 0;
    [SerializeField] protected int SecondaryGunPower = 0;

    [SerializeField] protected int ShipSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
