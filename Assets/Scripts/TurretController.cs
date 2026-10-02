using UnityEditor.Search;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TurretController : MonoBehaviour
{
private bool inRange = false;
private float cooldown = 0f;
private float maxCooldown = 1.5f;
   
    

    private void Start()
    {
       
    }

    private void Update()
    {
        if (inRange)
        {
            cooldown-= Time.deltaTime;
        
        if (cooldown <=0)
            {
                Shoot();
            }
        } 
    }

    private void Shoot()
    {
        cooldown = maxCooldown;

        print("Shoot Player");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            print("Player is in range");
            inRange = true;
        } 
    }

      public void OnTriggerExit2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            print("Player is out of range");
            inRange = false;
        } 
    }
}