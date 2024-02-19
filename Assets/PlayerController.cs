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
   private void Update() {
        
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;

        if(speedX < 0){
         sr.flipX = true;
        } else {
         sr.flipX = false;
        }

        if(speedX != 0 || speedY != 0){
         animator.SetFloat("X", speedX);
         animator.SetFloat("Y", speedY);
         if(!isMoving){
            isMoving = true;
            animator.SetBool("IsMoving", isMoving);
         } 
        } else {
            if(isMoving){
               isMoving = false;
               animator.SetBool("IsMoving", isMoving);
            }
         }


       
    }

    private void FixedUpdate(){
       UnityEngine.Vector2 movement = new UnityEngine.Vector2(speedX, speedY);

         rb.velocity = movement * movSpeed * Time.deltaTime;
    }
    
    private void StopMoving(){
      rb.velocity = UnityEngine.Vector2.zero;
    }

    
    
}
