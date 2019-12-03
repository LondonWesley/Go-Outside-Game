using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletingTask : MonoBehaviour
{
    public GameObject phone;
    public int indexOrder;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            phone = GameObject.Find("Canvas");
            PhoneScript phonescript = phone.GetComponent<PhoneScript>();
            phonescript.removeTask(indexOrder);
            this.gameObject.SetActive(false);
        }
    }
}
