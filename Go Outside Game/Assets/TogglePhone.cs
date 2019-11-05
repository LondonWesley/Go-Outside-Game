using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePhone : MonoBehaviour
{
    // Start is called before the first frame update
    public bool phoneIsUp = false;
    public GameObject IphoneUI;
    public List<GameObject> listOfTasks;
    public int[] time;
    public int taskCount = 0;
    public int currentTask = 0;
    // Update is called once per frame

    public void addTask(int timez)
    {
        if(taskCount < 9)
        {
            listOfTasks[taskCount].SetActive(true);
            taskCount++;

        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (phoneIsUp)
            {
                IphoneUI.SetActive(false);
                phoneIsUp = false;
            }   else {
                IphoneUI.SetActive(true);
                phoneIsUp = true;
            }     
        }
    }
}
