using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartGame(){
        //aqui va la escena del juego//
        SceneManager.LoadScene("MenuInicial");
        
    }
}