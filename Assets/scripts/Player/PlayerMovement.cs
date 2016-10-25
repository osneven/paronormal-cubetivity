using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;
    private Rigidbody playerBody;

    private Vector3 jumpVelocity;
    private Vector3 passiveVelocity;
    private PlayerGame playerGame;

    // Use this for initialization
    void Start() {

        // Initialize player fields
        player = GameObjectLibrary.Player;
        playerBody = this.GetComponent<Rigidbody>();
        playerGame = this.GetComponent<PlayerGame>();

        // Initialize velocity fields
        jumpVelocity = new Vector3(0, 15, 0);
        passiveVelocity = new Vector3(.1f, 0, 0);
    }
	
	// Update is called once per frame
	void Update() {

        // Controll jump and jump boost
        if (Input.GetKey("space") && CanJump()) {
            playerBody.velocity += jumpVelocity;
            playerGame.CheckChangeBackgroundColor();
        }

        // Controll passive movement
        player.transform.position += passiveVelocity;
	}

    // Checks if the player is able to jump at the current moment
    bool CanJump() {
        return playerBody.velocity.y == 0;
    }
}