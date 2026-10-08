using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
float speed = 8;
public Transform target; 
Vector3 target_position;

 private float cooldown = 1f;
private float maxCooldown = 1.5f;

    
    private void Start()
    {
       //get our target location
       target_position = target.position;

    }


    private void Update()
    {
        float step = speed * Time.deltaTime;
       //move towards our target
       transform.position = Vector3.MoveTowards(transform.position, target_position, step);

        cooldown-= Time.deltaTime;

        if (cooldown < 0)
        {
            Destroy(gameObject);
        }

    }

}
