using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager inst;
    int tiempo;
    int tiempoPas = 0;
    public Vida vida;

    private int puntos;
    private string puntosName = "Puntos";

    [SerializeField] PlayerMovement playerMovement;

    private void Awake ()
    {
        inst = this;
        puntos = 0;
    }

    private void Start () 
    {

	}

	private void Update () {
        tiempo = (int) Time.time;
        
        if (tiempo > tiempoPas)
        {
            playerMovement.velocidad += 0.2f;
            tiempoPas = tiempo;
            puntos++;
        }
	}


    public void SaveData()
    {
        PlayerPrefs.SetInt(puntosName, puntos);

    }
}