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

    //inventario
    public Item[] items;

    public void Start()
    {
        items = new Item[3];
    }

    public void AddItem(Item item)
    {
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
        Debug.Log("pierde una vida");
        vidas--;
        hud.desctiveVida(vidas);
    }

}
// Path: Assets/scrips/Item.cs
// Compare this snippet from Assets/scrips/Player.cs:
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//