using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Move(0, velocity);
        }
        if(Input.GetKey(KeyCode.S))
        {
            Move(0, -velocity);
        }
        if(Input.GetKey(KeyCode.A))
        {
            Move(-velocity, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            Move(velocity, 0);
        }
    }

    // movimento del player
    public void Move(float x, float y)
    {
        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
    }


}
