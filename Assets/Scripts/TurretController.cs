using Unity.Mathematics;
using UnityEditor.Search;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TurretController : MonoBehaviour
{
private bool inRange = false;
private float cooldown = 0f;
private float maxCooldown = 1.5f;
Transform target;

[SerializeField] private GameObject projectile_prefab;

 [SerializeField] Transform spawnpoint;

    

    private void Start()
    {
       cooldown = maxCooldown;
    }

    private void Update()
    {
        if (inRange)
        {
            cooldown-= Time.deltaTime;
        
        if (cooldown <=0)
            {
                Shoot();

                cooldown = maxCooldown;
            }
        } 
    }

    private void Shoot()
    {
        cooldown = maxCooldown;

        print("Shoot Player");

     GameObject fireball = Instantiate(projectile_prefab, spawnpoint.position, quaternion.identity);

     Projectile projectile= fireball.GetComponent<Projectile>();
     projectile.target = target;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            print("Player is in range");
            inRange = true;
            target = other.gameObject.transform;
        } 
    }

      public void OnTriggerExit2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            print("Player is out of range");
            inRange = false;
            target = null;
        } 
    }
}