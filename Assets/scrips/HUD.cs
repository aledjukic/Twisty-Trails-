using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TwistyTrails.Assets.scrips;

public class HUD : MonoBehaviour
{

    public Text textoLlaves;
    public GameObject[] vidas;
    private bool corazonParpadeando = false;

    public GameObject[] InventarySlots;

    public Sprite voidPanel;

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

    public void desctiveVida(int inidce)
    {
        vidas[inidce].SetActive(false);
    }

    public void activeVida(int inidce)
    {
        vidas[inidce].SetActive(true);
    }

    public void RemoveItem(Item item,int index)
    {
        InventarySlots[index].GetComponent<Image>().sprite = voidPanel;
        InventarySlots[index].GetComponent<SlotUsed>().isUsed = false;
    }   

    public void UpdateScore(int keys)
    {
        if (textoLlaves != null)
        {
            textoLlaves.text = keys.ToString();
        }
        else
        {
            Debug.LogWarning("La referencia al objeto de texto 'textoLlaves' no está asignada.");
        }

    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < InventarySlots.Length; i++)
        {
            if (InventarySlots[i].GetComponent<SlotUsed>().isUsed == false)
            {
                Debug.Log(item.nombre + " añadida al inventario");
                InventarySlots[i].GetComponent<Image>().sprite = item.imagen;
                InventarySlots[i].GetComponent<SlotUsed>().isUsed = true;
                break;
            }
        }
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
