using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToLiveOrDie : MonoBehaviour
{
    public bool MarchOn;
    public bool Return;
    public Button choice;
    // Start is called before the first frame update
    void Start()
    {
        choice.GetComponent<Button>();
        choice.onClick.AddListener(Decision);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Decision()
    {
        if(MarchOn == true)
        {
            SceneManager.LoadScene(1);
        } else if(Return == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
