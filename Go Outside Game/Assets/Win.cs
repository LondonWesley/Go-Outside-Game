using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject cam;
    float speed = 2f;
    bool driving = false;
    void Start()
    {
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            cam.SetActive(true);
            StartCoroutine("driveaway");
        }
    }

    IEnumerator driveaway()
    {
        yield return new WaitForSeconds(3f);
        driving = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(driving == true)
        {
            speed +=0.01f;
            transform.Translate(transform.forward + new Vector3(0, 0, speed * Time.deltaTime));
            //transform.Rotate(Vector3(0,0,0),transform);
        }
    }
}
