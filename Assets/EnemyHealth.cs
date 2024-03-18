using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator animator;
    public int currentHealth = 9;
    public int maxHealth = 9;

    private int vidaPerdidaFrame = 3; // El frame en el que se pierde vida
    // Start is called before the first frame update
    private float deathtime = 1.2f;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.lostVida();
        }
    }

    public void CheckFrame()
    {

            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // Si el frame actual de la animación es igual al frame donde se pierde vida
         if (stateInfo.normalizedTime * stateInfo.length >= vidaPerdidaFrame)
        {
            // Lógica para quitar vida al jugador
            GameManager.instance.lostVida();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            Destroy(this.gameObject, deathtime);
        }
        else 
        {
            animator.SetBool("isDead", false);
        }
    }
}
