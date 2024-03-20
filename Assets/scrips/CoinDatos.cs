using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDatos : MonoBehaviour
{
    GameObject player;
    bool puedeAgarrar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (puedeAgarrar)
        {
            player.GetComponent<Almacen>().cantCoins += 1;
            Destroy(gameObject);                  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            puedeAgarrar = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            puedeAgarrar = false;
    }
}
