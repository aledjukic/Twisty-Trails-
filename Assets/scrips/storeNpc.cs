using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeNpc : MonoBehaviour
{

    // Valor booleano para verificar si el jugador está dentro del trigger
    private bool playerInsideTrigger = false;

     void OnTriggerEnter2D(Collider2D  other)
    {
        // Verifica si el objeto que entró al trigger es el jugador
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D  other)
    {
        // Verifica si el objeto que salió del trigger es el jugador
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
        }
    }

     void Update()
    {
        // Verifica si el jugador está dentro del trigger y si presiona la tecla "F"
        if (playerInsideTrigger && Input.GetKeyDown(KeyCode.F))
        {
            // Realiza alguna acción cuando el jugador presiona la tecla "F" dentro del trigger
            Debug.Log("El jugador presionó la tecla 'F' dentro de la tienda");
        }
    }

}
