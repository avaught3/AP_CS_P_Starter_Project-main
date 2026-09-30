using UnityEditor.Experimental.GraphView;
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
  [SerializeField]  private int health = 3;
private Rigidbody2D body;
    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
       body = GetComponent<Rigidbody2D>();
        
        
       
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
       transform.position += new Vector3(xvector,yvector,0f);
       UpdateAnimation();
       body.linearVelocity = new Vector2(xvector, yvector) * speed;

    
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
        if (health <=0)
        {
            return;
        }

        health = health - amount;
        Debug.Log("Health: " + health);

        if (health <=0)
        {
            Debug.Log("PLayer died.");
        }
    }

    public void ChangeCoins(int amount)
    {
      coins = coins+amount;
           
            print("you have " + coins + " coins");  
    }
    
    public void ChangeHealth(int amount)
    {
        health += 1;
           
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
}