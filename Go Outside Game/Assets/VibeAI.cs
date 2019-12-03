using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VibeAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject hand;
    public GameObject face;

    public PlayerMovement playerMovement;
    public CameraScript playerCamScript;
    

    //Materials
    public Material roar, stare, idle;
    
    NavMeshAgent navMesh;
    bool vibeChecked = false;
    bool grabbing = false;
    void Start()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        hand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(player.transform.position);
        vibeCheck();

        if (grabbing)
        {
            hand.transform.Translate(0,0,(float)(1 * Time.deltaTime));
        }
    }
    void vibeCheck()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position)<=11 && !vibeChecked)
        {
            vibeChecked = true;
            playerMovement.enabled = false;
            playerCamScript.enabled = false;
            player.transform.LookAt(gameObject.transform);
            face.GetComponent<MeshRenderer>().material = roar;
            StartCoroutine("judge");
        }
    }
    IEnumerator judge()
    {
        yield return new WaitForSeconds(3f);
        face.GetComponent<MeshRenderer>().material = idle;
        StopCoroutine("judge");
        StartCoroutine("look");
    }
    IEnumerator look()
    {
        yield return new WaitForSeconds(3f);
        face.GetComponent<MeshRenderer>().material = stare;
        StopCoroutine("look");
        StartCoroutine("grab");
    }
    IEnumerator grab()
    {
        yield return new WaitForSeconds(5f);
        grabbing = true;
        hand.SetActive(true);
    }
}
