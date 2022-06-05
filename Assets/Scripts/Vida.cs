using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    PlayerMovement playerMovement;
    int vidaMax = 100;
    float vidaAct;
    float daño = 0.002f;
    public Image barraVida;
    float tiempo;

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        vidaAct = vidaMax;
        
    }

    void Update()
    {
        tiempo = Time.time;

        if (tiempo > 120)
        {
            daño = 0.01f;

        }
        else if (tiempo > 90)
        {
            daño = 0.008f;

        }
        else if (tiempo > 60)
        {
            daño = 0.006f;

        }
        else if (tiempo > 30)
        {
            daño = 0.004f;

        }

        QuitarVida(daño);
        RevisarVida();

        if (vidaAct <= 0)
        {
            playerMovement.Die();

        }
        
    }

    public void RevisarVida ()
    {
        if (vidaAct > vidaMax)
        {
            vidaAct = vidaMax;

        }

        barraVida.fillAmount = vidaAct / vidaMax;
    }
    
    public void QuitarVida (float vida)
    {
        vidaAct -= vida;
        
    }

    public void DarVida (float vida)
    {
        vidaAct += vida;

    }
}
