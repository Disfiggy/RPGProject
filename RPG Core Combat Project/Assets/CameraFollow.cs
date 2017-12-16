using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;


	// Use this for initialization
	void Start () {

        // Defining the player variable in the start by calling gameobjects and finding the GameObject with specific tag, in this case the Player, which is a third person character
        player = GameObject.FindGameObjectWithTag("Player");
        
        // For debugging and to just make Unity print the Player gameobject
        print(player.ToString());
	}
	
	// Update is called once per frame
	void LateUpdate () {

        // Because the script is attached to the Camera arm, we take the transform position of the camera and set it to be the same as the players transform position.
        transform.position = player.transform.position;

	}
}
