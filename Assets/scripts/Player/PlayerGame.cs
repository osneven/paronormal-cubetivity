using UnityEngine;
using System.Collections;

public class PlayerGame : MonoBehaviour {

    public int score;
    private int lastX;
    private GameObject player;

    private ArrayList cubes;
    private int maxCubes;

	// Use this for initialization
	void Start () {

        // Initialize player fields
        player = GameObject.Find("Player");

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
    }

    // Adds a cube for the player to jump on if some conditions are met
    void AddCube() {
        if (score >= 2) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(player.transform.position.x + 20, Random.Range(0, 5));
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
        }

        // Check if player fell below camera, and thus need to reset the game
        if (p.y <= -5) {
            Reset();
        }

        // Randomly add another cube to the scene
        if (Random.Range(0, 15) == 0) AddCube();
	}
}
