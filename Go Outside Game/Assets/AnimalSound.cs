using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    public AudioClip Behemoth_Growl_Low_Groam_01;

    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float distToVol = .2F;

    Transform playerTransform;
    Transform  targetTransform;
    RangeDetection detector;

    float nextCheck;
    float checkRate = 1f;


    // Start is called before the first frame update
    void Start()
    {
        checkRate = 1f;
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            targetTransform = playerTransform;
        }
    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextCheck)
        {
            findRangeForSound();
            nextCheck = Time.time + checkRate;
        }
    }


    public void findRangeForSound()
    {
        bool playerFound = false;
        GameObject closestObject = null;
        List<GameObject> targets = detector.getNearByObjects();
        if(targets.Count > 0)
        {
            closestObject = targets[0];
            float closestDist = Vector3.Distance(closestObject.transform.position, this.transform.position);
            foreach(GameObject current in targets)
            {
                if(current.tag == "Player")
                {
                    playerFound = true;
                    source.pitch = Random.Range(lowPitchRange, highPitchRange);
                    float Vol = Vector3.Distance(current.transform.position, this.transform.position) * distToVol;
                    source.PlayOneShot(Behemoth_Growl_Low_Groam_01, Vol);
                    //source.Play();
                }
            }
        } else {
            playerFound = false;
        }
        if(playerFound == false)
        {
            source.Stop();
        }
    }
}
