using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTasks : MonoBehaviour
{
    public GameObject[] Tasks;      //Array of Tasks
    public GameObject temp;
    public GameObject animal;//Temporary Game Object that will do the appearing and disappearing
    public Vector3 spawnValues;     //Vector that hold the values of the range of where spawning Tasks will take place
    public float spawnWait;         //These three variables are the time between each spawn (Range between leastWait to MostWait)
    public float spawnMostWait;
    public int difficulty = 30;
    public GameObject[] animals;
    public float spawnLeastWait;
    public GameObject phone;
    public Transform playerTransform;
    string[] todo =
    {
        "Car Tire", "Car Battery", "Engine Part", "Gas", "Steering Wheels", "Wrench", "Fuse", "Light Bulb", "Screw Driver", "Socket Wrench", 
    };

    public int startWait;           
    public int taskTime;            //Length of time that the task will stay

    int randTask;

    void Start()
    {
        difficulty = 25;
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
            StartCoroutine(waitTask());
        StartCoroutine(incDifficulty());
        StartCoroutine(mobSpawn());
    }

    IEnumerator mobSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            if (Random.Range(1, difficulty) < 5)
            {
                
                int rand = Random.Range(-50, 50);
                Debug.Log("A monster at " + rand);
                if (Mathf.Abs(rand)>10)
                    Instantiate(animal, (new Vector3(rand, 1, rand)) + playerTransform.position, Quaternion.Euler(new Vector3(0f, 9, 0f)));
            }
        }
    }
    void Update()
    {
        

       
        
    }

    IEnumerator waitTask()
    {
        int taskCounter = 0;
        while (taskCounter < Tasks.Length) {
           yield return new WaitForSeconds(0.01f);
            randTask = Random.Range(0, Tasks.Length);
            PhoneScript phonescript = phone.GetComponent<PhoneScript>();
            phonescript.addTask(taskTime, todo[taskCounter]);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            temp = Instantiate(Tasks[randTask], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            temp.SetActive(true);
           
          
         
            //yield return new WaitForSeconds(0.01f);
            taskCounter++;
        }
    }
    IEnumerator incDifficulty()
    {
        
       
        while (difficulty > 2)
        {
           
            difficulty-=1;
            Debug.Log("Difficulty increase");
            yield return new WaitForSeconds(10);


        }

    }

}
