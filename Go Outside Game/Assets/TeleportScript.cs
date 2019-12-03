using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    // Start is called before the first frame update

    Transform playerTransform;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject body = gameObject;
        // Debug.Log(Vector3.Distance(transfo
    }
}
