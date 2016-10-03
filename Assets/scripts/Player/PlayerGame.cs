using UnityEngine;
using System.Collections;

public class PlayerGame : MonoBehaviour {

    public int score;
    private int lastX;
    private GameObject player;
    private PlayerMovement playerMovement;
    private WorldGenerator worldGenerator;

	// Use this for initialization
	void Start () {

        // Initialize player fields
        player = GameObjectLibrary.Player;
        playerMovement = player.GetComponent<PlayerMovement>();

        // Inititlaize the world generator
        worldGenerator = player.GetComponent<WorldGenerator>();

        // Start by resetting the game
        Reset();
	}
	
    // Use this when game resets
    void Reset() {

        // Reset score
        score = 0;
        
        // Reset position
        player.transform.position = new Vector3(0, 1, 0);
        lastX = (int)player.transform.position.x;

        // Reset world generator
        worldGenerator.Reset();
    }   

	// Update is called once per frame
	void Update () {

        // Increase score
        UpdateScore();
        
        // Check for death
        CheckDeath();
	}

    // Check, and respawn, if death occurs
    void CheckDeath() {
        
        // Check if player fell below camera, and thus need to reset the game
        if (player.transform.position.y <= -5) {
            Reset();
        }
    }
    void OnTriggerEnter(Collider other) {
        
        // Check for respawn trigger
        if (other.tag == "Respawn") { Reset(); }

    }

    // Handle score increment
    void UpdateScore() {
        if (player.transform.position.x >= lastX + 10) {
            score += 1;
            lastX = (int)player.transform.position.x;
        }
    }
}
