using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
   public Transform target = null; 
   
    private bool inRange = false;
    Vector3 target_position;
    float speed = 3;
   [SerializeField] private GameObject detection;
 
    
    public void Start()
    {
         
           
    }

    public void Update()
    {
        if(target != null)
        {
        float step = speed * Time.deltaTime;
         target_position = target.position;
         transform.position = Vector3.MoveTowards(transform.position, target_position, step);
        }
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