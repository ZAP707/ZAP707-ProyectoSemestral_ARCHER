using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);   
    }

    public void Tienda()
    {
        SceneManager.LoadScene(4);
    }

    public void Opciones()
    {
        SceneManager.LoadScene(3);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    public void CargarNivel(string nombreNivel1)
    {
        SceneManager.LoadScene(nombreNivel1);
    }

    public void Regresar()
    {
        SceneManager.LoadScene(0);
    }


}
