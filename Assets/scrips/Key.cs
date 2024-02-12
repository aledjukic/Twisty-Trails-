using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLave : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.UpdateKeys(1);
            Debug.Log("Llave recogida");
            Destroy(gameObject);
        }
    }
}
