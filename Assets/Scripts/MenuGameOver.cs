using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    public GameObject menuGameOver;
    private JohnMovement johnMovement;

    private void Start()
    {
        johnMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<JohnMovement>();
        johnMovement.MuerteJugador += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
