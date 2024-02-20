using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    [SerializeField] protected int HullStrength = 100;
    [SerializeField] protected int ShieldLevel = 100;

    [SerializeField] protected int PrimaryGunPower = 25;
    [SerializeField] protected int SecondaryGunPower = 50;

    [SerializeField] protected int ShipSpeed = 3;

    public void InitializeShip(int HullStrength = 100, int ShieldLevel = 100, int PrimaryGunPower = 25, int SecondaryGunPower = 50, int ShipSpeed = 3)
    {
        this.HullStrength = HullStrength;
        this.ShieldLevel = ShieldLevel;

        this.PrimaryGunPower = PrimaryGunPower;
        this.SecondaryGunPower = SecondaryGunPower;

        this.ShipSpeed = ShipSpeed;
    }
}
