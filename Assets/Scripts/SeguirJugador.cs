using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador

    public Vector3 offset; // Offset opcional para ajustar la posición de la cámara

    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el seguimiento de la cámara

    void FixedUpdate()
    {
        // Calcula la posición a la que la cámara debería moverse
        Vector3 posicionDeseada = jugador.position + offset;

        posicionDeseada.z = -10;

        // Interpola suavemente la posición actual de la cámara hacia la posición deseada
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, smoothSpeed);

        posicionSuavizada.z = -10;

        // Asigna la nueva posición suavizada a la cámara
        transform.position = posicionSuavizada;
    }
}
