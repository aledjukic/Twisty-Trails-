using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
   public Animator animator;

   private SwordController swordController;

   private LevelLoader levelLoader;

   private bool isDead;
   public float movSpeed;

   private float attackTime = .25f;
   private float attackCounter = .25f;
   private bool isAttacking;

   public bool hasSword;

   float speedX, speedY;
   public bool isMoving;
   Rigidbody2D rb;
   private SpriteRenderer sr;
   // Start is called before the first frame update
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
      swordController = GameObject.Find("Sword").GetComponent<SwordController>();
      
   }

   // Update is called once per frame
   private void Update()
   {

      if (isDead)
      {
         StopMoving();
         animator.SetBool("isDead", isDead);
         return;
      }
      else if (isAttacking && hasSword == true)
      {
         attackCounter -= Time.deltaTime;
         if (attackCounter <= 0)
         {
            animator.SetBool("isAttacking", false);
            isAttacking = false;
         }
      }
      if (Input.GetKeyDown(KeyCode.E))
      {
         attackCounter = attackTime;
         animator.SetBool("isAttacking", true);
         isAttacking = true;
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
         
         if(hasSword)
         {
            animator.SetBool("hasSword", true);
         }
         else
         {
            bool sword = swordController.GetHasSword();
            if(sword){
            hasSword = true;
            animator.SetBool("hasSword", hasSword);
            }
         }
         

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
