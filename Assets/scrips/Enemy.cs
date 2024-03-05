using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Animator animator; // Referencia al componente Animator
    public bool isAnimated;

    public int vidaPerdidaFrame = 3; // El frame en el que se pierde vida

    void Start()
    {
        //animator = GetComponent<Animator>(); // Obtener el componente Animator
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Algo ha chocado con un enemigo");
        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Player ha chocado con un enemigo");
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


}
