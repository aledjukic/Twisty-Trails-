using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GameObject[] vidas;
    private bool corazonParpadeando = false;

    public void Update()
    {
        // Verifica si queda solo una vida y activa el parpadeo del corazón
        if (!vidas[1].activeSelf && !corazonParpadeando)
        {
            Debug.Log("Corazon parpadeando");
            corazonParpadeando = true;
            StartCoroutine(ParpadearCorazon());
        }
        // Si se recupera una vida, desactiva el parpadeo del corazón
        if (vidas[1].activeSelf && corazonParpadeando)
        {
            Debug.Log("Corazon dejó de parpadear");
            corazonParpadeando = false;
            StopCoroutine(ParpadearCorazon());
        }
    }

    public void UpadateScore(int score)
    {
        Debug.Log("Score: " + score);
    }

    public void desctiveVida(int inidce)
    {
        vidas[inidce].SetActive(false);
    }

    public void activeVida(int inidce)
    {
        vidas[inidce].SetActive(true);
    }

    IEnumerator ParpadearCorazon()
    {
        while (corazonParpadeando)
        {
            // Desactiva y activa el corazón cada cierto tiempo para simular el parpadeo
            vidas[0].SetActive(false);
            yield return new WaitForSeconds(0.5f);
            vidas[0].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
