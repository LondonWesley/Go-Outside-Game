using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAI : MonoBehaviour
{
    
    Transform playerTransform;
    public Transform targetTransform;
    RangeDetection detector;
    UnityEngine.AI.NavMeshAgent navMesh;
    public float checkRate = 1f;
    int maxSpeed = 12;
    //modes : 0 is neutral 1 is flee, 2 is attack
    public int mode = 0;
    float nextCheck;
    void Start()
    {
        checkRate = 1f;
        mode = 1;
        detector = this.transform.Find("DetectRange").GetComponent<RangeDetection>();
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            targetTransform = playerTransform;
        }
        navMesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time> nextCheck)
        {
            //neutral
            if (mode == 0)
            {
                checkRate = 1f;
                wander();
            }
            else if(mode == 1)
            {
                checkRate = 0.0001f;
                attack();   
            }
            nextCheck = Time.time + checkRate;
        }
    }

    public void attack()
    {
        GameObject target = this.findClosestTarget();
        if(target != null)
        {
            navMesh.SetDestination(target.transform.position);
            navMesh.transform.LookAt(target.transform);
            navMesh.speed = 12;
        }
        
    }
    //uses the objects found by the animal's detector object and finds the closest one
    //If it finds a player it will always be the closest object regardless.
    //So animals will join teams to fight the player
    public GameObject findClosestTarget()
    {
        GameObject closestObject = null;
        List<GameObject> targets = detector.getNearByObjects();
        if (targets.Count>0)
        {
            //assumes the closest object is the first one
            closestObject = targets[0];
            float closestDist = Vector3.Distance(closestObject.transform.position, this.transform.position);
            foreach( GameObject current in targets)
            {
                //if it's the player it will always take priority
                if (current.tag == "Player")
                    return current;
                float distance = Vector3.Distance(current.transform.position, this.transform.position);
                if(distance< closestDist)
                {
                    closestObject = current;
                    closestDist = distance;
                }
            }
        }
        return closestObject;
    }


    public void wander()
    {
        int action = Random.Range(1, 10);
        if(action == 1)
        {
            Vector3 selfPos = this.transform.position;
            Vector3 position = new Vector3(selfPos.x + Random.Range(-100.0f, 100.0f), 2, selfPos.z + Random.Range(-100.0f, 100.0f));
            navMesh.speed = Random.Range(0,maxSpeed);
            navMesh.SetDestination(position);
            navMesh.transform.LookAt(position);
        }
        if (action == 2)
        {
            Vector3 selfPos = this.transform.position;
            Vector3 position = new Vector3(selfPos.x ,0, selfPos.y);
            navMesh.speed = 0;
            navMesh.SetDestination(position);
            navMesh.transform.LookAt(playerTransform);
        }
    }


}
