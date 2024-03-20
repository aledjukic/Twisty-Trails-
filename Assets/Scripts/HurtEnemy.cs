using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damage = 3;
    public float thrust;
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
            EnemyHealth enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyhealth.TakeDamage(damage);
            
        }
    }

    
}
