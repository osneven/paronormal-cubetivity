using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private GameObject player;
    private GameObject camera;
    private float bodge;
    private float prevBodge = 0;

	// Use this for initialization
	void Start() {
        player = GameObjectLibrary.Player;
        camera = GameObjectLibrary.Camara;
        bodge = 0f;
	}
	
	// Update is called once per frame
	void Update() {

        // Make sure that the Main Camera follows the players x position
        MoveToPlayer();

        // Wave the camera
        DoWave();

    }

    // Handles the transformation of the camera
    void MoveToPlayer() {
        Vector3 p = player.transform.position;
        camera.transform.position = new Vector3(p.x, System.Math.Max(4, p.y), -10);
    }

    // Handles the waveing of the camera
    private void DoWave() {
        Vector3 p = camera.transform.position;
        float bodgeV = Mathf.Cos(bodge);
        camera.transform.position = new Vector3(p.x, p.y-.5f+bodgeV*.5f, p.z);
        bodge += Mathf.PI/20;
        prevBodge = bodgeV;
    }
}
