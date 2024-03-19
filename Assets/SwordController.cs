using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;

public class SwordController : MonoBehaviour
{
   public string SwordName;

    public Sprite spriteRenderer;

    public string descripcion;

    public int score = 0;

    public bool Hassword = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddItem(new Item { nombre = SwordName, descripcion = descripcion, imagen = spriteRenderer, score = score});
            Debug.Log("Espada recogida");
            Hassword = true;
            Destroy(gameObject);
        }
        
    }

    public bool GetHasSword()
    {
        return Hassword;
    }
}
