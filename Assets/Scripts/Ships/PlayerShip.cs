using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShip : Ship
{
    private Vector2 screenBounds;
    private float playerShipWidth;
    private float playerShipHeight;
    private float playerShipOffset;
    private const float playerShipOffsetPercent = 0.05f;

    private float verticalInput;
    private float horizontalInput;
    
    void Awake()
    {
        InitializeShip(ShipSpeed: 10);
    }
    
    // Start is called before the first frame update
    void Start()
    {   
        // Set the visible screen area
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Set the max amount in from the edge the ship should be allowed to hit
        playerShipOffset = screenBounds.x * playerShipOffsetPercent;
        
        // Set the player's ship width and height
        playerShipWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerShipHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        // Set the starting position of the player's ship
        transform.position = new(-screenBounds.x + playerShipOffset, 0, transform.position.z);
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
        // Move the player up and down
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * ShipSpeed * verticalInput * Vector3.up);

        // Move the player forward and backward
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Time.deltaTime * ShipSpeed * horizontalInput * Vector3.right);

        ClampPlayerMovement();
    }

    private void ClampPlayerMovement()
    {
        // The players current position
        Vector3 viewPosition = transform.position;

        // Keep the player inside the viewable area on the x-axis
        viewPosition.x = Mathf.Clamp(
            viewPosition.x, 
            (screenBounds.x * -1) + (playerShipWidth + playerShipOffset), 
            screenBounds.x - (playerShipWidth + playerShipOffset));
        
        // Keep the player inside the viewable area on the y-axis
        viewPosition.y = Mathf.Clamp(
            viewPosition.y, 
            (screenBounds.y * -1) + (playerShipHeight + playerShipOffset), 
            screenBounds.y - (playerShipHeight + playerShipOffset));

        // If the player will move outside the viewable area, reset the position
        transform.position = viewPosition;
    }
}
