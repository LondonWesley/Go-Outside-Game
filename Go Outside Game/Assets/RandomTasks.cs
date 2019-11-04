using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTasks : MonoBehaviour
{
    public GameObject[] Tasks;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool bye;

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
        yield return new WaitForSeconds(startWait);
        randTask = Random.Range(0, 1);

        Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
        Instantiate(Tasks[randTask], spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);
        if()
        {
            bye = false;
            ToggleVisibility();
        }
        yield return new WaitForSeconds(spawnWait);
    }

    public void ToggleVisibility()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();

        if(bye)
        {
            rend.enabled = false;
        } else
        {
            rend.enabled = true;
        }
    }
}
