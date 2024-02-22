using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShip : Ship
{
    /// <summary>
    /// The edge of the playable screen
    /// </summary>
    private Vector2 screenBounds;
    /// <summary>
    /// The width of the players ship object
    /// </summary>
    private float playerShipWidth;
    /// <summary>
    /// The height of the players ship object
    /// </summary>
    private float playerShipHeight;
    /// <summary>
    /// The amount of padding added when calculating the players movement space
    /// </summary>
    private float playerShipOffset;
    /// <summary>
    /// The percentage of screen space used for the playerShipOffset calculation
    /// </summary>
    private const float playerShipOffsetPercent = 0.05f;
    
    // Awake is called before Start
    // Calling InitializeShip here ensures it is filly ready when it is needed.
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
    // void Update()
    // {

    // }

    // LateUpdate is called just after Update
    // Calling MoveShip here makes the movements a little smoother
    void LateUpdate()
    {
        MoveShip();
    }

    /// <summary>
    /// Move the player ship around the screen
    /// </summary>
    private void MoveShip()
    {
        float verticalInput;
        float horizontalInput;

        // Move the player up and down
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * ShipSpeed * verticalInput * Vector3.up);

        // Move the player forward and backward
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Time.deltaTime * ShipSpeed * horizontalInput * Vector3.right);

        ClampPlayerMovement();
    }

    /// <summary>
    /// Keep the player ship on the screen
    /// </summary>
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
