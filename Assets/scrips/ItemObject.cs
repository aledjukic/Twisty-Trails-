using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwistyTrails.Assets.scrips;

public class LLave : MonoBehaviour
{
<<<<<<< HEAD
    private SpriteRenderer sr;
    private BoxCollider2D boxcollider;
=======
    [SerializeField] private AudioClip pickKeySoundClip;
>>>>>>> 11f4699edc8a0756d03bea88c11e62949e0d8050
    public string keyName;

    public Sprite spriteRenderer;

    public string descripcion;

    public int score = 0;

    public int slimecounter;

    public bool isRiddle;
    public GameObject[] values;

    private bool alldead = false;

    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.AddItem(new Item { nombre = keyName, descripcion = descripcion, imagen = spriteRenderer, score = score});
            Debug.Log("Llave recogida");
            Destroy(gameObject);
            SoundFXManager.instance.PlaySoundFXCLip(pickKeySoundClip, transform, 1f);
        }
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
        if(isRiddle)
        {
            sr.enabled = false;
            boxcollider.enabled = false;

        }
    }
    void Update()
    {
        if(isRiddle)
        {
            RiddleConditions(values);
        }
        
    }

    public void RiddleConditions(GameObject[] values)
    {
        
        int deadslimes = 0;
        foreach(GameObject monster in values)
        {
            if(monster == null)
            {
                deadslimes++;
                Debug.Log("Muertos" + deadslimes);
                if(deadslimes >= slimecounter)
                {
                    alldead = true;
                    break;
                }
            }
        }

        if(alldead == true)
        {
            sr.enabled = true;
            boxcollider.enabled = true;
        }
        
    }
}