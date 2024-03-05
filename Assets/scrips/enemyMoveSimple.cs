using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoveSimple : MonoBehaviour
{
 public Transform[] targetPositions;
    public float moveSpeed = 5f;

    private int currentTargetIndex = 0;

    private void Update()
    {
        // Calcula la dirección hacia el objetivo
        Vector3 direction = (targetPositions[currentTargetIndex].position - transform.position).normalized;

        // Mueve al enemigo hacia el objetivo
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Comprueba si el enemigo ha llegado a su destino actual
        if (Vector3.Distance(transform.position, targetPositions[currentTargetIndex].position) < 0.1f)
        {
            // Cambia al siguiente destino
            currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
        }
    }
}
