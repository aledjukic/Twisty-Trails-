using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damage = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter2D (Collider2D collision) 
    {
        if(collision.tag == "Enemy")
        {
            EnemyHealth enemy= collision.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);

        }
    }

    
}
