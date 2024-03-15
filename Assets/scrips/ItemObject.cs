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

    public int slimecounter;
    public GameObject[] values;

    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddItem(new Item { nombre = keyName, descripcion = descripcion, imagen = spriteRenderer, score = score});
            Debug.Log("Llave recogida");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        this.gameObject.SetActive(false);
        RiddleConditions(values);
        
    }

    public void RiddleConditions(GameObject[] values)
    {
        bool allDead = false;

        foreach(GameObject monster in values)
        {
            EnemyHealth slime = monster.GetComponent<EnemyHealth>();

            if(slime.CheckifDead() == true)
            {
                if(slimecounter == 0)
                {
                    allDead = true; 
                }
                else
                {
                    slimecounter--;
                }
            }
        }

        if(allDead == true)
        {
            this.gameObject.SetActive(true);
        }
        
    }
}



    
