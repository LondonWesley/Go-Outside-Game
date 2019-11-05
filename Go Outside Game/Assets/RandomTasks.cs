using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTasks : MonoBehaviour
{
    public GameObject[] Tasks;      //Array of Tasks
    public GameObject temp;         //Temporary Game Object that will do the appearing and disappearing
    public Vector3 spawnValues;     //Vector that hold the values of the range of where spawning Tasks will take place
    public float spawnWait;         //These three variables are the time between each spawn (Range between leastWait to MostWait)
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;           
    public int taskTime;            //Length of time that the task will stay

    int randTask;

    void Start()
    {
        StartCoroutine(waitTask());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitTask()
    {
        int taskCounter = 0;
        while (taskCounter < Tasks.Length) {
            yield return new WaitForSeconds(startWait);
            randTask = Random.Range(0, Tasks.Length);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            temp = Instantiate(Tasks[randTask], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            temp.SetActive(true);
            yield return new WaitForSeconds(taskTime);
            temp.SetActive(false);
            yield return new WaitForSeconds(spawnWait);
        }
    }

}
