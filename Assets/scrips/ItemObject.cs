using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;

public class LLave : MonoBehaviour
{

    public string keyName;

    public Sprite spriteRenderer;

    public string descripcion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddItem(new Item { nombre = keyName, descripcion = descripcion, imagen = spriteRenderer});
            Debug.Log("Llave recogida");
            Destroy(gameObject);
        }
    }
}
