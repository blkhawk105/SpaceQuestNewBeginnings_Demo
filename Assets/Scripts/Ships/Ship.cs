using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    
    /// <summary>
    /// The total strength of the ship without shields
    /// </summary>
    [SerializeField] protected int HullStrength = 100;
    /// <summary>
    /// Remaining shield percentage expressed as an int
    /// </summary>
    [SerializeField] protected int ShieldLevel = 100;

    /// <summary>
    /// The amount of damage done by a single hit from the primary gun
    /// </summary>
    [SerializeField] protected int PrimaryGunPower = 25;
    /// <summary>
    /// The amount of damage done by a single hit from the secondary gun
    /// </summary>
    [SerializeField] protected int SecondaryGunPower = 50;

    /// <summary>
    /// The ships movement speed
    /// </summary>
    [SerializeField] protected int ShipSpeed = 3;

    /// <summary>
    /// A convenient place to set the initial property values for a new ship
    /// </summary>
    /// <param name="HullStrength">The total strength of the ship without shields</param>
    /// <param name="ShieldLevel">Remaining shield percentage expressed as an int</param>
    /// <param name="PrimaryGunPower">The amount of damage done by a single hit from the primary gun</param>
    /// <param name="SecondaryGunPower">The amount of damage done by a single hit from the secondary gun</param>
    /// <param name="ShipSpeed">The ships movement speed</param>
    public void InitializeShip(int HullStrength = 100, int ShieldLevel = 100, int PrimaryGunPower = 25, int SecondaryGunPower = 50, int ShipSpeed = 3)
    {
        this.HullStrength = HullStrength;
        this.ShieldLevel = ShieldLevel;

        this.PrimaryGunPower = PrimaryGunPower;
        this.SecondaryGunPower = SecondaryGunPower;

        this.ShipSpeed = ShipSpeed;
    }
}
