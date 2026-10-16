using System;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private static readonly int WalkDirHash = Animator.StringToHash("WalkDir");
    float speed=4;
    float xdirection;
    float ydirection;
    float xvector;
    float yvector;
     private Animator anim;
    private SpriteRenderer renderer;
  [SerializeField]  private int coins;
  [SerializeField]  private int health = 7;
private Rigidbody2D body;
private float cooldown = 0f;
private float maxCooldown = 1.5f;
private bool inRange = false;
Transform target;
String facing;



[SerializeField] private GameObject projectile_prefab;

    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
       body = GetComponent<Rigidbody2D>();
        cooldown = maxCooldown;
       
       
    }

    private void Update()
    {
       //get input
       xdirection = Input.GetAxis("Horizontal");
       ydirection = Input.GetAxis("Vertical");
       //create vector
       xvector = xdirection * speed * Time.deltaTime;
       yvector = ydirection * speed * Time.deltaTime;
       //move by vector amount
       if (xdirection>0)
        {
            facing = "Right";
        }
        else if (xdirection<0)
        {
            facing = "Left";
        }
        else if (ydirection>0)
        {
            facing = "Up";
        }
        else if (ydirection<0)
        {
            facing = "Down";
        }
       transform.position += new Vector3(xvector,yvector,0f);
       UpdateAnimation();
       body.linearVelocity = new Vector2(xvector, yvector) * speed;
       if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           cooldown-= Time.deltaTime;
      
        if (cooldown <=0)
            {
                Shoot();

                cooldown = maxCooldown;
            }
        } 
        if (Input.GetKeyDown(KeyCode.LeftShift))
         {
        print("shoot");
        Shoot();
       }
   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
           
            Destroy(other.gameObject);
           
            ChangeCoins(5);
        }
        if (other.CompareTag("HealthPotion"))
        {
            health += 1;
            Destroy(other.gameObject);
          
        }
        if (other.gameObject.CompareTag("E_Fireball"))
        {
           ChangeHealth(-3);
            Destroy(other.gameObject);
        }
    
    }

    void UpdateAnimation()
    {
        bool isMoving = xvector !=0 || yvector !=0;
        anim.SetBool("IsWalking", isMoving);

        if (Mathf.Abs(xvector) > Mathf.Abs(yvector))
        {
            anim.SetInteger("WalkDir", 1);
            if (xvector < 0)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }
        }
        else if (yvector > 0)
        {
            anim.SetInteger("WalkDir", 0);
        }
        else if (yvector < 0)
        {
            anim.SetInteger("WalkDir", 2);
        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            TakeDamage(1);
        }
        
    }
    

    private void TakeDamage(int amount)
    {
       
        health = health - amount;
         Debug.Log("Health " + health);
        if (health <=0)
        {
            Debug.Log("Player died.");
        }
          if (health <=0)
        {
            return;
        }
    }

    public void ChangeCoins(int amount)
    {
      coins = coins+amount;
           
            print("you have " + coins + " coins");  
    }
    
    public void ChangeHealth(int amount)
    {
     
            print("you have " + health + " health");
             health = health - amount;
      
        Debug.Log("Health: " + health);

        if (health <=0)
        {
            Debug.Log("PLayer died.");
        }

    }

    void Die()
    {
        print("You died.");
        //reload scence
    }

    private void Shoot()
    {
        cooldown = maxCooldown;
         GameObject Fireball = Instantiate(projectile_prefab, transform.position, quaternion.identity);

        PlayerProjectile projectile= Fireball.GetComponent<PlayerProjectile>();
        projectile.SetDirection(facing);
   
    }
  void OnTriggerEnter(Collider other)
    {
       
    } 
  

}