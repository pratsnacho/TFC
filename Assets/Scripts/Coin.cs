using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour {

    float vida = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "aj")
        {
            return;
        }

        if (other.gameObject.GetComponent<Vida>() != null)
        {
            other.gameObject.GetComponent<Vida>().DarVida(vida);
        }

        Destroy(gameObject);

    }

    private void Start () {

    }

	private void Update () {
	}
}