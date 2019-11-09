using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAI : MonoBehaviour
{
    
    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent navMesh;
    public float checkRate = 0.01f;
    float nextCheck;
    void Start()
    {
       
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
   
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        navMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time> nextCheck)
        {
            lookAt(playerTransform);
            goTo(playerTransform);
            nextCheck = Time.time + checkRate;
        }
    }

    public void lookAt(Transform targetTransform)
    {
        navMesh.transform.LookAt(targetTransform);
    }
    public void goTo(Transform targetTransform)
    {
        navMesh.SetDestination(targetTransform.position);
    }
}
