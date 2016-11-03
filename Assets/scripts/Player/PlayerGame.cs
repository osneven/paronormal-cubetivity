using UnityEngine;
using System.Diagnostics;
using System.Collections;
using UnityEngine.UI;

public class PlayerGame : MonoBehaviour {

    public int score;
    private int lastX;
    private GameObject player;
    private Camera camera;
    private PlayerMovement playerMovement;
    private WorldGenerator worldGenerator;

    public float msBetweenColorChange = 100;
    private float lastColorChangeTime = 0;

    public Material color0;
    public Material color1;
    public Material color2;
    public Material color3;
    public Material color4;
    public Material color5;
    public Material color6;
    private ArrayList colors;
    
    public Text ScoreField;

    // Use this for initialization
    void Start() {

        // Initialize color array
        colors = new ArrayList();
        colors.Add(color0);
        colors.Add(color1);
        colors.Add(color2);
        colors.Add(color3);
        colors.Add(color4);
        colors.Add(color5);
        colors.Add(color6);

        // Initialize player fields
        player = GameObjectLibrary.Player;
        playerMovement = player.GetComponent<PlayerMovement>();

        // Inititlaize the world generator
        worldGenerator = player.GetComponent<WorldGenerator>();

        // Initialize camera fields
        camera = GameObjectLibrary.Camara.GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;

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

        // Change background color
        // CheckChangeBackgroundColor();

        // Makes the score appear on screen
        ScoreField.text = "Score: " + score;
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

    // Check for background color change
    public void CheckChangeBackgroundColor() {
        float now = Time.realtimeSinceStartup * 1000;
        if (lastColorChangeTime == 0 || now - lastColorChangeTime >= msBetweenColorChange) {
            lastColorChangeTime = now;
            ChangeBackgroundColor();
        }
    }

    // Change the background color
    void ChangeBackgroundColor() {

        // Pick random material
        Material m = (Material)colors[UnityEngine.Random.RandomRange(0, 5)];
        while (m.color == camera.backgroundColor)
            m = (Material)colors[UnityEngine.Random.RandomRange(0, 5)];

        // Set the background material to the choosen one
        camera.backgroundColor = m.color;
    }
}
