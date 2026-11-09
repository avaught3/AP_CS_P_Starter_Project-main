using UnityEngine;
using System.Collections.Generic;
public class Platform : MonoBehaviour
{
    float speed=1;
    [SerializeField] private List<Transform> targetTransforms = new List<Transform>();
   int patrolNumber = 0;
 Vector3 target_position;

 public Transform target = null; 
 public bool isOn = false;

    void Start()
    {
         target = targetTransforms[0];
           target_position = target.position;
    }

    // Update is called once per frame
    void Update()
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
        
        if(isOn)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target_position, step);
        }
        
    }


}
