using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "StatsData", menuName = "StatsData")]
public class StatsData : ScriptableObject 
{
    [SerializeField] private int vidas;
    [SerializeField] private int maxVidas;
    [SerializeField] private int damage;
    [SerializeField] private int score;
    [SerializeField] private float speed;

    //getters
    public int Vidas { get { return vidas; } }
    public int MaxVidas { get { return maxVidas; } }
    public int Damage { get { return damage; } }
    public int Score { get { return score; } }
    public float Speed { get { return speed; } }

    //setter
    public void SetVidas(int vidas) { this.vidas = vidas; }
    public void SetMaxVidas(int maxVidas) { this.maxVidas = maxVidas; }
    public void SetDamage(int damage) { this.damage = damage; }
    public void SetScore(int score) { this.score = score; }
    public void SetSpeed(float speed) { this.speed = speed; }

    public void SetAllStats(int vidas, int maxVidas, int damage, int score, float speed)
    {
        this.vidas = vidas;
        this.maxVidas = maxVidas;
        this.damage = damage;
        this.score = score;
        this.speed = speed;
    }
   
}
