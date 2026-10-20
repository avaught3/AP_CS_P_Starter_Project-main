using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
   public Transform target = null; 
   
    private bool inRange = false;
    Vector3 target_position;
    float speed = 3;
   [SerializeField] private GameObject detection;
   bool attacking = false;
   [SerializeField] private List<Transform> targetTransforms = new List<Transform>();
   int patrolNumber = 0;
    
    public void Start()
    {
         target = targetTransforms[0];
           target_position = target.position;
    }

    public void Update()
    {
        if(inRange)
        {
             target_position = target.position;
        }
       else
        {
            target_position = targetTransforms[patrolNumber].position;

            if(Vector3.Distance(transform.position, targetTransforms[patrolNumber].position)<.1)
            {
                patrolNumber +=1;
                if(patrolNumber == targetTransforms.Count)
                {
                    patrolNumber =0;
                }
            }
        }
        float step = speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, target_position, step);
        
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