using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;

public class LLave : MonoBehaviour
{

    public string keyName;

    public Sprite spriteRenderer;

    public string descripcion;

    public int score = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Sound
            GameManager.instance.AddItem(new Item { nombre = keyName, descripcion = descripcion, imagen = spriteRenderer, score = score});
            Debug.Log("Llave recogida");
            Destroy(gameObject);
        }
    }
}
