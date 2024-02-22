using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShip : Ship
{
    private GameManager gameManager;

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
        // Get a reference to the game manager
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        //Set the max amount in from the edge the ship should be allowed to hit
        playerShipOffset = gameManager.ScreenBounds.x * playerShipOffsetPercent;
        
        // Set the player's ship width and height
        playerShipWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerShipHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        // Set the starting position of the player's ship
        transform.position = new(-gameManager.ScreenBounds.x + playerShipOffset, 0, transform.position.z);
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
            (gameManager.ScreenBounds.x * -1) + (playerShipWidth + playerShipOffset), 
            gameManager.ScreenBounds.x - (playerShipWidth + playerShipOffset));
        
        // Keep the player inside the viewable area on the y-axis
        viewPosition.y = Mathf.Clamp(
            viewPosition.y, 
            (gameManager.ScreenBounds.y * -1) + (playerShipHeight + playerShipOffset), 
            gameManager.ScreenBounds.y - (playerShipHeight + playerShipOffset));

        // If the player will move outside the viewable area, reset the position
        transform.position = viewPosition;
    }
}
