using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour

{
    public Animator animator;

    public Transform player;
    public float moveSpeed = 5f;
    public float followDistance = 5f; // Distancia a partir de la cual el enemigo seguirá al jugador
    public float stopFollowDistance = 10f; // Distancia a partir de la cual el enemigo dejará de seguir al jugador
    public float raycastDistance = 1f; // Distancia del raycast para la comprobación de colisión

    private void Update()
    {
        // Calcula la distancia al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de seguimiento
        if (distanceToPlayer <= followDistance)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Lanza un rayo en la dirección del movimiento
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
            {
                // Si el rayo golpea algo, comprueba si es el jugador
                if (hit.collider.CompareTag("Player"))
                {
                    // Mueve al enemigo hacia el jugador
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }
                // Si golpea algo más, no hacemos nada (por ejemplo, no avanzamos)
            }
            else
            {
                // Si no golpea nada, mueve al enemigo hacia el jugador
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
        // Si el jugador está fuera del rango de dejar de seguir
        else if (distanceToPlayer > stopFollowDistance)
        {
            // No hacemos nada, el enemigo permanece en su posición
        }
    }
}
