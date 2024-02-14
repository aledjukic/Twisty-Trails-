using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaExtra : MonoBehaviour
{
  
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Algo ha chocado con un enemigo");
        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Player ha chocado con un enemigo");
            GameManager.instance.restoreVida();
            Destroy(gameObject);
        }
    }

}
