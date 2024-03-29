using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;

public class Chest : MonoBehaviour
{
    [SerializeField] private AudioClip chestSoundClip;
    public Item item;

    private bool isOnTrigger = false;

      private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el collider que entró es el del jugador
        if (other.CompareTag("Player"))
        {
            // Hacer algo cuando el jugador entra en el trigger
            Debug.Log("El jugador ha entrado en el trigger del cofre.");
            //si el jugadro presiona E y el inventario no esta lleno
            isOnTrigger = true;
        }
    }

    void Update()
    {
        // Hacer algo si el jugador presiona la tecla E
        if (Input.GetKeyDown(KeyCode.F) && isOnTrigger)
        {
             Debug.Log("El jugador ha presionado la tecla F.");
                //añadir el objeto al inventario
                GameManager.instance.AddItem(item);
                Destroy(this.gameObject);
                //reproducir sonido
                SoundFXManager.instance.PlaySoundFXCLip(chestSoundClip, transform, 1f);
                
                
        }
    }

}
