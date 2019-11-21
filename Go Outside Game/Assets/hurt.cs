using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt : MonoBehaviour
{
    // Start is called before the first frame update
 
    public player otherscript;
    void Start()
    {
       
       
    }
    void OnCollisionEnter(Collision collision)
    {
      

        if (collision.gameObject.CompareTag("Animal"))
        {
            otherscript.health -= 10;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
