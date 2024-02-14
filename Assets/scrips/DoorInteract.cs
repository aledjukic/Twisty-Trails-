using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;
public class DoorInteract : MonoBehaviour
{
    public string typeDoor = "Golden";

    public Sprite doorOpen;

    public string keyName = "Golden Key";
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
    // Detecta si se presiona la tecla F
    void Update()
    {
        if (isOnTrigger && Input.GetKeyDown(KeyCode.F))
        {
            // Busca si tienes la llave en el inventario
            if (GameManager.instance.CheckItem(new Item { nombre = keyName, descripcion = "Llave", imagen = null }))
            {
                Debug.Log("Tienes la llave dorada");
                //desactiva la colision de la puerta
                Collider2D[] colliders = GetComponents<Collider2D>();
                colliders[1].enabled = false;
                // Cambia el sprite de la puerta a una puerta abierta en el mismo tamaño
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = doorOpen;

                // Ajusta la escala para que coincida con el tamaño original
                float scaleX = transform.localScale.x;
                float scaleY = transform.localScale.y;

                // Obtiene el tamaño original del sprite
                float originalWidth = spriteRenderer.sprite.bounds.size.x;
                float originalHeight = spriteRenderer.sprite.bounds.size.y;

                // Calcula la escala necesaria para que coincida con el tamaño original
                float newScaleX = scaleX * (originalWidth / spriteRenderer.bounds.size.x);
                float newScaleY = scaleY * (originalHeight / spriteRenderer.bounds.size.y);

                // Aplica la escala calculada
                transform.localScale = new Vector3(newScaleX, newScaleY, 1f);
                //elimina la llave del inventario
                GameManager.instance.RemoveItem(new Item { nombre = keyName, descripcion = "Llave", imagen = null });
            }
            else
            {
                Debug.Log("No tienes la llave dorada");
            }
        }
    }

}
