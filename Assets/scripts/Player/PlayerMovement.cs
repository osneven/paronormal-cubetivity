using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;
    private Rigidbody playerBody;

    private GameObject camera;
    private CameraMovement cameraMovement;

    private Vector3 jumpVelocity;
    public Vector3 passiveVelocity;
    private PlayerGame playerGame;

    private bool canJump;
    private int firstGround = 2;

    // Use this for initialization
    void Start() {

        // Initialize player fields
        player = GameObjectLibrary.Player;
        playerBody = this.GetComponent<Rigidbody>();
        playerGame = this.GetComponent<PlayerGame>();

        // Initialize camera fields
        camera = GameObjectLibrary.Camara;
        cameraMovement = camera.GetComponent<CameraMovement>();

        // Initialize velocity fields
        jumpVelocity = new Vector3(0, 6.5f, 0);
        passiveVelocity = new Vector3(.17f, 0, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        
        // Controll jump and jump boost
        if (Input.GetKey("space") && canJump) {
            DoJump();
        }

        // Controll passive movement
        player.transform.position += passiveVelocity;
	}

    // Handle the players jump
    void DoJump() {

        // Set the actual jump velocity
        playerBody.velocity += jumpVelocity;
    }

    // Handle collision enter: jump varialbe
    void OnCollisionEnter(Collision col) {
        if (col.collider.gameObject.tag == "ground") {
            canJump = true;
            playerGame.CheckChangeBackgroundColor();
            if (firstGround == 0) {
                //cameraMovement.ExecuteBodge();
            } else firstGround--;
            Debug.Log(firstGround);
        }
    }

    // Handle collision exit: jump variable
    void OnCollisionExit(Collision col) {
        if (col.collider.gameObject.tag == "ground")
            canJump = false;
    }
}