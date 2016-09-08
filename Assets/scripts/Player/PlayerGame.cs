using UnityEngine;
using System.Collections;

public class PlayerGame : MonoBehaviour {

    public int score;
    private int lastX;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        Reset();
	}
	
    // Use this when game resets
    void Reset() {

        // Reset score
        score = 0;

        // Reset position
        player.transform.position = new Vector3(-10, 6, 0);
        lastX = (int)player.transform.position.x;
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
	}
}
