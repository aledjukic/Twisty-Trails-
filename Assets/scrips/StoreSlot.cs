using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TwistyTrails.Assets.scrips;

public class StoreSlot : MonoBehaviour, IPointerClickHandler
{

    public Item item; // El objeto que se vende en este slot de la tienda
    public int precio; // El precio del objeto que se vende en este slot de la tienda
    private Image itemImage; // Referencia al componente Image del objeto hijo del panel
    private Text itemNameText; // Referencia al componente Text del nombre del item
    private Text itemPriceText; // Referencia al componente Text del precio del item

    void Start()
    {
        // Obtener la referencia al componente Image del objeto hijo del panel
        itemImage = transform.GetChild(0).GetComponent<Image>();
        // Obtener la referencia al componente Text del nombre del item
        itemNameText = transform.GetChild(1).GetComponent<Text>();
        // Obtener la referencia al componente Text del precio del item
        itemPriceText = transform.GetChild(2).GetComponent<Text>();

        // Actualizar el sprite del objeto hijo con el sprite del item actual
        if (item != null)
        {
            itemImage.sprite = item.imagen;
            itemNameText.text = item.nombre;
            itemPriceText.text = precio.ToString();
        }
    }

    // Este método se llama cuando se hace clic en el slot
    public void OnPointerClick(PointerEventData eventData)
    {
        // Si el jugador tiene suficiente dinero para comprar el item
        if (GameManager.instance.score >= precio)
        {
            // Restar el precio del item al score del jugador
            GameManager.instance.score -= precio;
            GameManager.instance.hud.UpdateScore(GameManager.instance.score);

            //cierra la tienda
            GameObject storePanel = GameObject.Find("Storemenu");
            storePanel.SetActive(false);
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar este item.");
            return;
        }

        //Dependiendo del item que compres se ejecutara una accion
        switch (item.nombre)
        {
            case "Posicion":
                GameManager.instance.restoreVida();
                break;
            case "Vida Extra":
                Debug.Log("Vida Extra");
                break;
            case "Daño Extra":

                Debug.Log("Daño Extra");
                break;
            case "Velocidad":
                GameManager.instance.SpeedIncrease(0.2f);
                Debug.Log("Velocidad");
                break;
            case "Llave dorada":
                Debug.Log("Llave dorada obtenida");
                break;
            default:
                Debug.Log("El item no tiene una accion asociada.");
                break;
        }
        
        // Aquí puedes agregar la lógica para realizar acciones específicas cuando el jugador haga clic en este slot
    }
}
