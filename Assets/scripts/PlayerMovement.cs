using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;
    private Rigidbody playerBody;
    private Vector3 jumpVelocity;
    private Vector3 passiveVelocity;

    // Use this for initialization
    void Start() {
        // Initialize player fields
        player = GameObject.Find("Player");
        playerBody = this.GetComponent<Rigidbody>();

        // Initialize velocity fields
        jumpVelocity = new Vector3(0, 7, 0);
        passiveVelocity = new Vector3(.1f, 0, 0);
    }
	
	// Update is called once per frame
	void Update() {

        // Controll jump
        if (Input.GetKeyDown("space") && CanJump()) playerBody.velocity += jumpVelocity;

        // Controll passive movement
        player.transform.position += passiveVelocity;
	}

    // Checks if the player is able to jump at the current moment
    bool CanJump() {
        return playerBody.velocity.y == 0;
    }
}
