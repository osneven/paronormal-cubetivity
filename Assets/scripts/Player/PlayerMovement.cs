using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;
    private Rigidbody playerBody;

    private Vector3 jumpVelocity;
    public Vector3 passiveVelocity;
    private PlayerGame playerGame;

    private bool CanJump;

    // Use this for initialization
    void Start() {

        // Initialize player fields
        player = GameObjectLibrary.Player;
        playerBody = this.GetComponent<Rigidbody>();
        playerGame = this.GetComponent<PlayerGame>();

        // Initialize velocity fields
        jumpVelocity = new Vector3(0, 6.5f, 0);
        passiveVelocity = new Vector3(.17f, 0, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        
        // Controll jump and jump boost
        if (Input.GetKey("space") && CanJump) {
            playerBody.velocity += jumpVelocity;
            playerGame.CheckChangeBackgroundColor();
        }

        // Controll passive movement
        player.transform.position += passiveVelocity;
	}

    // Handle collision enter: jump varialbe
    void OnCollisionEnter(Collision col) {
        if (col.collider.gameObject.tag == "ground")
            CanJump = true;
    }

    // Handle collision exit: jump variable
    void OnCollisionExit(Collision col) {
        if (col.collider.gameObject.tag == "ground")
            CanJump = false;
    }
}