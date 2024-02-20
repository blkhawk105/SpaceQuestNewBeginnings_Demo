using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShip : Ship
{
    private Vector2 screenBounds;
    private float playerShipWidth;
    private float playerShipHeight;

    private float verticalInput;
    private float horizontalInput;
    
    new int HullStrength = 0;
    new int ShieldLevel = 0;

    new int PrimaryGunPower = 0;
    new int SecondaryGunPower = 0;

    new int ShipSpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the visible screen area
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // Set the player's ship width and height
        playerShipWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerShipHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        // Set the starting position of the player's ship in from the left edge 15% of the playable area
        // This is set 30% of half the playable area.
        transform.position = new(-screenBounds.x + screenBounds.x * 0.3f, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // MoveShip();
    }

    void LateUpdate()
    {
        MoveShip();

    }

    private void MoveShip()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * ShipSpeed * verticalInput * Vector3.up);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Time.deltaTime * ShipSpeed * horizontalInput * Vector3.right);

        ClampPlayerMovement();
    }

    private void ClampPlayerMovement()
    {
        Vector3 viewPosition = transform.position;

        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x * -1 + playerShipWidth, screenBounds.x - playerShipWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenBounds.y * -1 + playerShipHeight, screenBounds.y - playerShipHeight);

        transform.position = viewPosition;
    }
}
