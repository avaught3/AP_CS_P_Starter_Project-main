using UnityEngine;

public class StatManager : MonoBehaviour
{
public int health;
public int coins;

public static StatManager original;


void Awake()
    {
        if (original != null && original != this)
        {
            Destroy(gameObject);
            return;
        }
        original = this;
        DontDestroyOnLoad(gameObject);
    }




    public void ChangeCoins(int amount)
    {
      coins = coins+amount;
           
            print("you have " + coins + " coins");  
    }

     public void ChangeHealth(int amount)
    {
     
            print("you have " +health + " health");
             health = health + amount;
      
        Debug.Log("Health: " + health);

        if (health <=0)
        {
            Debug.Log("PLayer died.");
        }

    }

}
