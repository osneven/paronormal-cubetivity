using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private GameObject player;
    private GameObject camera;

	// Use this for initialization
	void Start () {
        player = GameObjectLibrary.Player;
        camera = GameObjectLibrary.Camara;
	}
	
	// Update is called once per frame
	void Update () {

        // Make sure that the Main Camera follows the players x position
        Vector3 p = player.transform.position;
        camera.transform.position = new Vector3(p.x, System.Math.Max(5, p.y), -10);
	}
}
