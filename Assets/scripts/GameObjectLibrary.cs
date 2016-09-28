using UnityEngine;
using System.Collections;

public class GameObjectLibrary : MonoBehaviour {

    private static GameObject camera = GameObject.Find("Main Camera");
    public static GameObject Camara {
        get { return camera; }
    }
    private static GameObject player = GameObject.Find("Player");
    public static GameObject Player {
        get { return player; }
    }

}
