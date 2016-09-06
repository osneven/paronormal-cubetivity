using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private GameObject player;
    private GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        // Make sure that the Main Camera follows the players x position
        camera.transform.position = new Vector3(player.transform.position.x, 5, -10);
	}
}
