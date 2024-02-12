using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public HUD hud;

    public static GameManager instance { get; private set; }

    public int score = 0;

    private int vidas = 3;

    public void UpdateScore(int score)
    {
        this.score += score;
        hud.UpadateScore(score);
    }

    public void Awake()
    {
        if(instance == null)
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
        if(vidas < 3)
        {
            vidas++;
            hud.activeVida(vidas-1);
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
