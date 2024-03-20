using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    private bool enZona;

    public void Update()
    {
        if (enZona)
        {
            GameManager.instance.lostVida();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enZona = true;
        }
    }
}
