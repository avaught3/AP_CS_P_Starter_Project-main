using System;
using System.Numerics;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float speed = 10;
    Vector3 direction = new Vector3(1,0);
     float xvector;
    float yvector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

   public void SetDirection(String facing)
    {
        if (facing == "Right")
        {
            direction = new Vector3

        }
    }
}
