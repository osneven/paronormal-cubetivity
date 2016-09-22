using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {

    // Set obstacles from unity editors
    public GameObject obstacle0;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstacle5;
    public GameObject obstacle6;
    public GameObject obstacle7;

    private ArrayList obstacles;
    private ArrayList physicalObstacles;
    private float positionX; // What x position the next obstacle needs to spawn at

    // Use this for initialization
    void Start () {
        obstacles = new ArrayList();
        obstacles.Add(new Obstacle(obstacle0));
        physicalObstacles = new ArrayList();
        positionX = 12.5f;
	}
	
	// Update is called once per frame
	void Update () {

        // Choose a random obstacle form the list to use
        Obstacle obstacleToSpawn = (Obstacle)obstacles[Random.Range(0, obstacles.Count - 1)];

        // Spawn the choosen obstacle
        GameObject physicalObstacle = (GameObject)Instantiate(obstacleToSpawn.gameObject, new Vector3(positionX, 0), new Quaternion());

        // Set the next spawn x location
        positionX += obstacleToSpawn.length;
	}

    // Store information for obstacles
    private class Obstacle {
        public GameObject gameObject;
        public float length;

        public Obstacle(GameObject gameObject) {
            this.gameObject = gameObject;
            this.length = totalLengthOfOject();
        }

        // Get the x difference between the parent game object and it's furthes away child object
        private float totalLengthOfOject() {
            Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform>();
            Transform parentTransform = gameObject.transform;
            float longestX = 0;
            foreach (Transform t in childrenTransforms) {
                float lengthX = t.position.x - parentTransform.position.x;
                longestX = Mathf.Max(longestX, lengthX);
            }
            return longestX;
        }
    }
}
