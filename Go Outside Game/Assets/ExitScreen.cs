using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScreen : MonoBehaviour
{
    // Start is called before the first frame update
    double timer = 100;

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (timer < 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
