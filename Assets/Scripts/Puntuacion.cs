using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    int puntuacion;
    private string puntosName = "Puntos";
    public Text mensaje;

    void Start()
    {
        
    }

    void Update()
    {
        LoadData();
        mensaje.text = "Has durado " + GetPuntuacion() + " días sin contagiarte";

    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("Juego");

    }

    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu Principal");

    }

    private void LoadData()
    {
        puntuacion = PlayerPrefs.GetInt(puntosName, 0);

    }

    private string GetPuntuacion()
    {
        return puntuacion.ToString();

    }
}
