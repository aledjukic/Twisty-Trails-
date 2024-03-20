using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPideMonedas : MonoBehaviour
{
    GameObject player;
    bool enZona;
    public GameObject dialogo1;
    public GameObject dialogo2;
    public GameObject dialogo3;
    public static SkullPideMonedas instance { get; private set; }
    public bool ya = true;
    public bool ganado = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogo1.SetActive(true);
        dialogo2.SetActive(false);
        dialogo3.SetActive(false);
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("GameManager instance already exists");
        }
    }

    private void Update()
    {
        if (ya == false)
        {
            dialogo1.SetActive(false);
            ya = false;
        }

        if (player.GetComponent<Almacen>().cantCoins >= 2)
        {
            dialogo2.SetActive(false);
            dialogo3.SetActive(true);
            Debug.Log("¡Mision Completada!");
        }

        if (enZona && Input.GetKeyDown(KeyCode.F))
        {
            if (player.GetComponent<Almacen>().cantCoins >= 2)
            {
                ganado = true;
                Debug.Log("¡Mision Completada!");
                player.GetComponent<Almacen>().cantCoins -= 2;
                GameManager.instance.UpdateScore(100);
            }

            else if (player.GetComponent<Almacen>().cantCoins < 2 && ganado == false)
            {
                Debug.Log("Esto se hace otra vez.");
                dialogo2.SetActive(true);
                dialogo3.SetActive(false);
            
                Debug.Log("La cantidad de monedas no es suficiente.");
            
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            enZona = true;
        }
    }

    public void desactivarDialogo()
    {
        dialogo1.SetActive(false);
    }
}
