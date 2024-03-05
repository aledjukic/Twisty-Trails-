using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Animator animator;
    public float invincibilityDuration = 2f; // Duración de la invencibilidad en segundos
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
   [SerializeField] private AudioClip swordSoundClip;
   private bool isDead;
   public float movSpeed;
   float speedX, speedY;
   public bool isMoving;
   Rigidbody2D rb;
   private SpriteRenderer sr;
   // Start is called before the first frame update
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
   }

   // Update is called once per frame
   private void Update()
   {
      if (isInvincible)
        {
            // Parpadeo del jugador
            float blinkTime = Mathf.PingPong(Time.time * 5, 1); // Velocidad de parpadeo
            sr.enabled = blinkTime > 0.5f;

            // Control de temporizador de invencibilidad
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
                sr.enabled = true; // Asegúrate de que el jugador no quede invisible al finalizar la invencibilidad
            }
        }
      if (isDead)
      {
         StopMoving();
         animator.SetBool("isDead", isDead);
         return;
      }
      else
      {

         speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
         speedY = Input.GetAxisRaw("Vertical") * movSpeed;

         if (speedX < 0)
         {
            sr.flipX = true;
         }
         else
         {
            sr.flipX = false;
         }

         if (speedX != 0 || speedY != 0)
         {
            animator.SetFloat("X", speedX);
            animator.SetFloat("Y", speedY);
            if (!isMoving)
            {
               isMoving = true;
               animator.SetBool("IsMoving", isMoving);
            }
         }
         else
         {
            if (isMoving)
            {
               isMoving = false;
               animator.SetBool("IsMoving", isMoving);
            }
         }

      }
   }

   public void takeDamage()
    {
      Debug.Log("Player has taken damage");
        if (!isInvincible)
        {
            // Realizar acciones para cuando el jugador recibe daño
            // Por ejemplo, reducir la salud del jugador o ejecutar animaciones

            isInvincible = true;
            invincibilityTimer = invincibilityDuration;
        }
    }

   private void FixedUpdate()
   {
      if (!isDead)
      {
         UnityEngine.Vector2 movement = new UnityEngine.Vector2(speedX, speedY);
         rb.velocity = movement * movSpeed * Time.deltaTime;
      }
      else
      {
         rb.velocity = UnityEngine.Vector2.zero;
      }
   }


   private void StopMoving()
   {
      rb.velocity = UnityEngine.Vector2.zero;
   }

   public void killPlayer()
   {
      isDead = true;
   }


}
