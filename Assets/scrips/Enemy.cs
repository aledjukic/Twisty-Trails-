using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Animator animator; // Referencia al componente Animator

    private Transform target;
    public Transform homePos;
    public float speed;
    
    private float maxRange = .5f;
    private float minRange = .125f; 

    private SpriteRenderer sr;


    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        sr = GetComponent<SpriteRenderer>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        { 
            FollowPlayer();
        }
        else
        {
            GoHome();  
        }
        
    }

    public void FollowPlayer()
    {
        sr.flipX = false; 
        animator.SetBool("isMoving", true);
        animator.SetFloat("MoveX", target.position.x - transform.position.x);
        animator.SetFloat("MoveY", target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        if(transform.position == homePos.position)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
            transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
        }
    }

}
