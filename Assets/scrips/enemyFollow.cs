using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.Collections;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    public Animator animation;

    public Transform player;
    public float moveSpeed = 5f;
    public float followDistance = 5f;
    public float stopFollowDistance = 10f;
    public float raycastDistance = 1f;
    private bool isMoving = false;
    private bool isDead = false;
    Rigidbody2D rb;

    private void Update()
    {
        float distanceToPlayer = UnityEngine.Vector3.Distance(transform.position, player.position);

        if (isDead)
        {
            StopMoving();
            animation.SetBool("isDead", isDead);
            return;
        }
        else
        {
            if (distanceToPlayer <= followDistance)
        {
            UnityEngine.Vector3 direction = (player.position - transform.position).normalized;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    transform.position += direction * moveSpeed * Time.deltaTime;
                    isMoving = false;
                    animation.SetBool("isWalking", false);
                    Debug.Log("estoy loco");
                }
                else
                {
                    isMoving = false;
                    animation.SetBool("isWalking", false);
                    Debug.Log("ooooo");
                }
            }
            else
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
                isMoving = true;
                animation.SetBool("isWalking", true);
            }
        }
        else 
        {
            isMoving = false;
            animation.SetBool("isWalking", false);
            Debug.Log("se paró");
        }
    }
        }

    private void StopMoving()
    {
        rb.velocity = UnityEngine.Vector2.zero;
    }

}
