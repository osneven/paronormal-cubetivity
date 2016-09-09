﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private GameObject player;
    private Rigidbody playerBody;
    private Vector3 jumpVelocity;
    private Vector3 jumpVelocityBoost;
    public Vector3 scaleVelocity;

    private bool isJumpBoosting;
    private Vector3 passiveVelocity;
    private PlayerGame playerGame;

    // Use this for initialization
    void Start() {

        // Initialize player fields
        player = GameObject.Find("Player");
        playerBody = this.GetComponent<Rigidbody>();
        playerGame = this.GetComponent<PlayerGame>();

        // Initialize velocity fields
        jumpVelocity = new Vector3(0, 4, 0);
        jumpVelocityBoost = jumpVelocity * 3;
        isJumpBoosting = false;
        passiveVelocity = new Vector3(.1f, 0, 0);
        scaleVelocity = new Vector3(1, 0, 0);
    }
	
	// Update is called once per frame
	void Update() {

        // Controll jump and jump boost
        if (Input.GetKey("space")) {
            if (CanJump()) {
                playerBody.velocity += jumpVelocity;
                isJumpBoosting = true;
            } else if (isJumpBoosting) {
                playerBody.velocity += jumpVelocityBoost; //new Vector3(0, 6, 0);
                jumpVelocityBoost *= .65f;
            }
        } else {
            isJumpBoosting = false;
            jumpVelocityBoost = jumpVelocity / 2;
        }

        // Controll passive movement
        player.transform.position += passiveVelocity * scaleVelocity.x;       
	}

    // Checks if the player is able to jump at the current moment
    bool CanJump() {
        return playerBody.velocity.y == 0;
    }
}