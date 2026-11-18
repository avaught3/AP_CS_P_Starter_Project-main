using UnityEngine;
using TMPro;
public class StatManager : MonoBehaviour
{
public int health;
public int coins;

public static StatManager original;
[SerializeField]TextMeshProUGUI coinText;
[SerializeField]TextMeshProUGUI healthText;

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

void Start()
    {
        coinText.text = "Coins: " +coins;
       healthText.text = "Health: " +health;
    }


    public void ChangeCoins(int amount)
    {
      coins = coins+amount;
           
            coinText.text = "Coins: " +coins;
           
    }

     public void ChangeHealth(int amount)
    {
         health = health + amount;
         
            healthText.text = "Health: " +health;
     
        //print("you have " +health + " health");
      
        Debug.Log("Health: " + health);

        if (health <=0)
        {
            Debug.Log("PLayer died.");
        }

    }
 
}
