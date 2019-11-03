using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePhone : MonoBehaviour
{
    // Start is called before the first frame update
    public bool phoneIsUp = false;
    public GameObject IphoneUI;


    // Update is called once per frame
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
