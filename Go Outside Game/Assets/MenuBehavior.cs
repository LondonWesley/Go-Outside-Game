using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;
    public bool isCredits;
    public Button interaction;

    // Start is called before the first frame update
    void Start()
    {
        interaction.GetComponent<Button>();
        interaction.onClick.AddListener(ClickedAction);
    }

    // Update is called once per frame
    void ClickedAction()
    {
        if(isStart == true)
        {
            SceneManager.LoadScene(1);
        } else if(isQuit == true)
        {
            Application.Quit();
        } else if(isCredits == true)
        {
            
        }
    }
}
