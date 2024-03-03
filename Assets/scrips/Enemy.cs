using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Animator animator; // Referencia al componente Animator
    public bool isAnimated;

    public int currentHealth = 9;
    public int maxHealth = 9;
    public int vidaPerdidaFrame = 3; // El frame en el que se pierde vida

    void Start()
    {
        //animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            
            GameManager.instance.lostVida();
        }
        //imprime el frame actual de la animación
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime * animator.GetCurrentAnimatorStateInfo(0).length);
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
            Destroy(this.gameObject);
        }
    }
    


}
