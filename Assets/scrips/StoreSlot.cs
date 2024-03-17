using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TwistyTrails.Assets.scrips;

public class StoreSlot : MonoBehaviour, IPointerClickHandler
{

    public Item item; // El objeto que se vende en este slot de la tienda
    private Image itemImage; // Referencia al componente Image del objeto hijo del panel
    private Text itemNameText; // Referencia al componente Text del nombre del item

    void Start()
    {
        // Obtener la referencia al componente Image del objeto hijo del panel
        itemImage = transform.GetChild(0).GetComponent<Image>();
        itemNameText = GetComponentInChildren<Text>();

        // Actualizar el sprite del objeto hijo con el sprite del item actual
        if (item != null)
        {
            itemImage.sprite = item.imagen;
            itemNameText.text = item.nombre;
        }
    }

    // Este método se llama cuando se hace clic en el slot
    public void OnPointerClick(PointerEventData eventData)
    {
        //Dependiendo del item que compres se ejecutara una accion
        switch (item.nombre)
        {
            case "Posion":
                GameManager.instance.restoreVida();
                break;
            default:
                Debug.Log("El item no tiene una accion asociada.");
                break;
        }
        
        // Aquí puedes agregar la lógica para realizar acciones específicas cuando el jugador haga clic en este slot
    }
}
