using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;

public class GameManager : MonoBehaviour
{

    public HUD hud;

    public static GameManager instance { get; private set; }

    [SerializeField] private StatsData statsData;

    //objetos guardados
    public int score = 0;

    private int vidas = 3;
    private int maxVidas = 3;

    [SerializeField] private AudioClip takeDamageClip;

    public PlayerController player;

    //inventario
    public Item[] items;

    public void Start()
    {
        items = new Item[3];
        hud.UpdateScore(this.score);
        //setea los stats iniciales 
        int newVidas = statsData.Vidas;
        int newMaxVidas = statsData.MaxVidas;
        int newDamage = statsData.Damage;
        //player.setDamage(newDamage);
        int newHudVidas = newMaxVidas - 3;
        for (int i = 0; i < newHudVidas; i++)
        {
            Debug.Log("Vida: " + i);
            createVida();
            //hud.activeVida(i+3);
        }
        float newSpeed = statsData.Speed;
        player.movSpeed = newSpeed;
        int newScore = statsData.Score;
        Debug.Log("Score: " + newScore);
        UpdateScore(newScore);
    }

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

    public void SpeedIncrease(float speed)
    {
        statsData.SetSpeed(player.movSpeed + speed);
        player.movSpeed += speed;
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
        return false;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        hud.UpdateScore(this.score);
        statsData.SetScore(this.score);
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(player);
        }
        else
        {
            Debug.Log("GameManager instance already exists");
            //Destroy(player);
        }
    }

    public void restoreVida()
    {
        if (vidas < maxVidas)
        {
            vidas++;
            hud.activeVida(vidas - 1);
        }
        else
        {
            Debug.Log("Ya tienes todas las vidas");
        }
    }

    public void createVida()
    {   
        //recupera todas las vidas
        vidas = maxVidas;
        //inserta un nuevo corazon en el hud y aumenta el limite de vidas
        hud.createVida(vidas);
        vidas++;
        maxVidas++;
        statsData.SetMaxVidas(maxVidas);
        statsData.SetVidas(vidas);
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
            SoundFXManager.instance.PlaySoundFXCLip(takeDamageClip, transform, 1f);
            hud.desctiveVida(vidas);
            player.takeDamage();
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

    public int getScore()
    {
        return score;
    }

    public void ocultarInventario()
    {
        hud.ocultarInventario();
    }

    public void mostrarInventario()
    {
        hud.mostrarInventario();
    }

}
// Path: Assets/scrips/Item.cs
// Compare this snippet from Assets/scrips/Player.cs:
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//