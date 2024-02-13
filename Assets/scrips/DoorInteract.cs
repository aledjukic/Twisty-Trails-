using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorInteract : MonoBehaviour
{
    public string typeDoor = "Golden";
    private bool isFPressed = false;
    private bool isOnTrigger = false;

    // Cuando el jugador está cerca y presiona la F abre la puerta
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entró es el jugador
        if (other.CompareTag("Player"))
        {
            isOnTrigger = true;
            Debug.Log("Puerta abierta");
        }
    }

    // Cuando el jugador sale del trigger
    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que salió es el jugador
        if (other.CompareTag("Player"))
        {
            isOnTrigger = false;
        }
    }

    // Detecta si se presiona la tecla F
    void Update()
    {
        if (isOnTrigger && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Se presiona la F");
            if (typeDoor == "Golden")
            {
                Debug.Log("Puerta dorada abierta");
            }
            else if (typeDoor == "Silver")
            {
                Debug.Log("Puerta plateada abierta");
            }
        }
    }
}
