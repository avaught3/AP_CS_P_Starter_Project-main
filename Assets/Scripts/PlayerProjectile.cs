using System;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float speed = 10;
    Vector3 direction = new (1,0);
    Vector3 target_position;
    public Transform target; 
    private float cooldown = 1f;
private float maxCooldown = 1.5f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        
           transform.position += direction * step;
              cooldown-= Time.deltaTime;

        if (cooldown < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(String facing)
    {
        if (facing == "Right") 
        {
            direction = new Vector3(1, 0, 0);
        }
        else if (facing == "Left")
        {
            direction = new Vector3(-1, 0, 0);
        }
         else if (facing == "Up")
        {
            direction = new Vector3(0, 1, 0);
        }  
          else if (facing == "Down")
        {
            direction = new Vector3(0, -1, 0);
        }
    }
}
