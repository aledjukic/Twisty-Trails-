using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;

public class GameManager : MonoBehaviour
{

    public HUD hud;

    public static GameManager instance { get; private set; }

    //objetos guardados
    public int score = 0;

    private int vidas = 3;

    public PlayerController player;

    //inventario
    public Item[] items;

    public void Start()
    {
        items = new Item[3];
    }

    //añdade un item al invertario del jugador
    public void AddItem(Item item)
    {   //cuando se añade un objeto al inventario aumenta el score
        this.score += item.score;
        hud.UpdateScore(score);
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                hud.AddItem(item);
                break;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].nombre == item.nombre)
            {
                items[i] = null;
                hud.RemoveItem(item, i);
                break;
            }
        }
    }

    //verifica si tienes el objeto en el inventario// verifica si tienes el objeto en el inventario
    public bool CheckItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].nombre == item.nombre)
            {
                return true;
            }
        }
        Debug.Log("No tienes el objeto en el inventario");
        return false;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        hud.UpdateScore(this.score);
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("GameManager instance already exists");
        }
    }

    public void restoreVida()
    {
        if (vidas < 3)
        {
            vidas++;
            hud.activeVida(vidas - 1);
        }
        else
        {
            Debug.Log("Ya tienes todas las vidas");
        }
    }

    public void lostVida()
    {
        if (vidas == 0)
        {
            return;
        }
        else
        {
            vidas--;
            hud.desctiveVida(vidas);
            player.takeDamage();
            Debug.Log("pierde una vida");
        }
    }

    public void Update()
    {
        if (vidas == 0)
        {
            //Debug.Log("Game Over");
            player.killPlayer();
            hud.isDeadPlayer();
        }

    }

}
// Path: Assets/scrips/Item.cs
// Compare this snippet from Assets/scrips/Player.cs:
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//