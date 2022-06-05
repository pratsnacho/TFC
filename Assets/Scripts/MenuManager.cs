using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("Juego");

    }

    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu Principal");

    }

    public void Salir()
    {
        Application.Quit();

    }
}
