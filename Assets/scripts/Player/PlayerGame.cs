using UnityEngine;
using System.Collections;

public class PlayerGame : MonoBehaviour {

    public int score;
    private int lastX;
    private GameObject player;
    private PlayerMovement playerMovement;

    private ArrayList cubes;
    private int maxCubes;

	// Use this for initialization
	void Start () {

        // Initialize player fields
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        // Initialze cube fields
        cubes = new ArrayList();
        maxCubes = 3;

        // Start by resetting the game
        Reset();
	}
	
    // Use this when game resets
    void Reset() {

        // Reset score
        score = 0;

        // Reset position
        player.transform.position = new Vector3(-6, 3, 0);
        lastX = (int)player.transform.position.x;

        // Delete all previously made cubes
        foreach (GameObject cube in cubes) {
            Destroy(cube);
        }

        // Reset scale velocity
        playerMovement.scaleVelocity = new Vector3(1, 0, 0);
    }

    // Adds a cube for the player to jump on if some conditions are met
    void AddCube() {
        if (score >= 1) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(player.transform.position.x + 20, Random.Range(0, 50));
            cube.transform.localScale = new Vector3(Random.Range(5,7), 1, 1);
            cubes.Add(cube);
        }
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

        // Randomly add another cube to the scene
        if (Random.Range(0, 10) == 0) AddCube();
	}
}
