using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

    PlayerMovement playerMovement;

	private void Start () {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        
    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.name == "aj") {
            // Kill the player
            playerMovement.Die();
        }
    }

    private void Update () {
	
	}
}