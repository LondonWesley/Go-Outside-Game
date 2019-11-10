using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objectsInRange = new List<GameObject>();
    void Start()
    {
        
    }

    public List<GameObject> getNearByObjects()
    {
        return objectsInRange;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Untagged") && collision.gameObject.transform.parent != this.transform.parent)
        {
            if (!objectsInRange.Contains(collision.gameObject))
            {
                objectsInRange.Add(collision.gameObject);
                Debug.Log("object:" + collision.gameObject.name);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        objectsInRange.Remove(other.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("clearing");
    }
}
