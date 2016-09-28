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
        player = GameObject.Find("Player");
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
        player.transform.position = new Vector3(0, 3, 0);
        lastX = (int)player.transform.position.x;

        // Reset scale velocity
        playerMovement.scaleVelocity = new Vector3(1, 0, 0);

        // Reset world generator
        worldGenerator.Reset();
    }   

	// Update is called once per frame
	void Update () {
        Vector3 p = player.transform.position;

        // Increase score
	    if (p.x >= lastX + 10) {
            score += 1;
            lastX = (int)p.x;

            // Increase player velocity
            playerMovement.scaleVelocity *= 1.0005f;
        }

        // Check if player fell below camera, and thus need to reset the game
        if (p.y <= -5) {
            Reset();
        }
	}
}
