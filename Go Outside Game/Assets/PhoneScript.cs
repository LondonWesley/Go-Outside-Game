using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool phoneIsUp = false;
    public GameObject IphoneUI;
    public List<GameObject> listOfTasks;
    public int[] time;
    public int taskCount = 0;
    public int currentTask = 0;
    // Update is called once per frame

    public void addTask(int timeLimit, string desc)
    {
        if(taskCount < 9)
        {
            GameObject task = listOfTasks[taskCount];
            task.transform.parent.gameObject.SetActive(true);
           //Component[] tester = task.GetComponents(typeof(Component)); // this lets you see the name of the kinds of components inside
           // for (int i = 0; i < tester.Length; i++)
           //     Debug.Log(tester[i]);
            task.GetComponent<TextMeshProUGUI>().SetText(desc);
            taskCount++;

        }
    }
    //task boxes will use this to remove the task from the phone
    public void removeTask(int index)
    {
        if (taskCount > 0)
        {
            taskCount--;
            GameObject task = listOfTasks[taskCount];
            task.transform.parent.gameObject.SetActive(false);
            
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
