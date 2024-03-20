using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInicial : MonoBehaviour
{
    public void StartGame(){
        //aqui va la escena del juego//
        SceneManager.LoadScene("Tutorial");
        
    }

    public void Quit(){
        Debug.Log("Se ha salido del juego");
        Application.Quit();
    }
}
