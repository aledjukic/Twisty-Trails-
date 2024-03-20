using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TwistyTrails.Assets.scrips;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] private AudioClip deathSoundClip;
    [SerializeField] private AudioClip lowLifeClip;
    public Text textoLlaves;
    public GameObject[] vidas;
    private bool corazonParpadeando = false;
    private bool sonidoLowLifeReproducido = false;
    private bool sonidoDeathReproducido=false;
   
    public GameObject[] InventarySlots;

    public Sprite voidPanel;

    private bool isDead;

    public void Update()
    {
        // Si el jugador está muerto, no hace falta que el corazón parpadee
        if (isDead)
        {
            if (!sonidoDeathReproducido){
                ReproducirSonidoMuerte();
                sonidoDeathReproducido = true;
            }
            corazonParpadeando = false;
            StartCoroutine(mostrarGameOver());     
        }
        else
        {
            if (vidas[1].activeSelf == false && vidas[2].activeSelf == false)
            {
                corazonParpadeando = true;
                if (!sonidoLowLifeReproducido)
                {
                    ReproducirSonidoVidaBaja();
                    sonidoLowLifeReproducido = true;
                }
                StartCoroutine(ParpadearCorazon());
                
            }
            else{
                corazonParpadeando = false;
                sonidoLowLifeReproducido = false;
                vidas[0].SetActive(true);
                //Debug.Log("No parpadea");
            }
        }
    }

    private void ReproducirSonidoVidaBaja(){
       SoundFXManager.instance.PlaySoundFXCLip(lowLifeClip, transform, 1f);
    }
    private void ReproducirSonidoMuerte(){
       SoundFXManager.instance.PlaySoundFXCLip(deathSoundClip, transform, 1f);
       SoundFXManager.instance.StopSoundFXClip(lowLifeClip);
    }    
    IEnumerator mostrarGameOver(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }

    public void isDeadPlayer()
    {
        isDead = true;
    }   

    IEnumerator ParpadearCorazon()
    {
        while (corazonParpadeando)
        {
            // Alternar entre activado y desactivado con un intervalo de tiempo
            vidas[0].SetActive(!vidas[0].activeSelf);
            yield return new WaitForSeconds(0.5f); // Cambiar este valor según el tiempo deseado de parpadeo
        }
    }

    public void desctiveVida(int inidce)
    {
        Debug.Log(inidce);
        vidas[inidce].SetActive(false);
    }

    public void activeVida(int inidce)
    {
        vidas[inidce].SetActive(true);
    }

    public void RemoveItem(Item item, int index)
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
    public void ocultarInventario()
    {
        for (int i = 0; i < InventarySlots.Length; i++)
        {
            InventarySlots[i].SetActive(false);
        }
    }

    public void mostrarInventario()
    {
        for (int i = 0; i < InventarySlots.Length; i++)
        {
            InventarySlots[i].SetActive(true);
        }
    }

}
