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
    private const float defaultPositionX = 12.5f;
    private float positionX; // What x position the next obstacle needs to spawn at

    private GameObject player;
    private GameObject camera;

    // Use this for initialization
    void Start () {
        obstacles = new ArrayList();
        obstacles.Add(new Obstacle(obstacle0));
        obstacles.Add(new Obstacle(obstacle1));
        physicalObstacles = new ArrayList();
        positionX = defaultPositionX;
        player = GameObjectLibrary.Player;
        camera = GameObjectLibrary.Camara;
	}
	
	// Update is called once per frame
	void Update () {

        // Remove obstacles
        RemoveObsoleteObstacles();

        // Check if a new obstacle can be spawned
        if (physicalObstacles.Count < 4)
            SpawnNewObstacle();
	}

    // Remove obsolete obstacles (those that moved passed the screen)
    private void RemoveObsoleteObstacles() {
        for (int i = 0; i < physicalObstacles.Count; i++) {
            Obstacle obstacle = (Obstacle)physicalObstacles[i];
            if (obstacle.gameObject.transform.position.x + obstacle.length + ((Obstacle)physicalObstacles[(int)Mathf.Min(i + 1, physicalObstacles.Count - 1)]).length + ((Obstacle)physicalObstacles[(int)Mathf.Min(i + 2, physicalObstacles.Count - 1)]).length <= player.transform.position.x) {
                Destroy(obstacle.gameObject);
                physicalObstacles.Remove(obstacle);
            }
        }
    }

    // Spawn a new obstacle
    private void SpawnNewObstacle() {
        // Choose a random obstacle form the list to use
        Obstacle obstacleToSpawn = (Obstacle)obstacles[Random.Range(0, obstacles.Count)];

        // Spawn the choosen obstacle and add it to the list
        GameObject physicalObstacle = (GameObject)Instantiate(obstacleToSpawn.gameObject, new Vector3(positionX, 0), new Quaternion());
        physicalObstacles.Add(new Obstacle(physicalObstacle));

        // Set the next spawn x location
        positionX += obstacleToSpawn.length;
    }

    // Resets the world
    public void Reset() {
        foreach (Obstacle obstacle in physicalObstacles)
            Destroy(obstacle.gameObject);
        physicalObstacles.Clear();
        positionX = defaultPositionX;
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
                float lengthX = t.position.x + t.lossyScale.x - parentTransform.position.x;
                longestX = Mathf.Max(longestX, lengthX);
            }
            return longestX;
        }
    }
}
