using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalModelConfig : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject animalModel;
    public GameObject MeshLoader;
    void Start()
    {
        animalModel.AddComponent<BoxCollider>();
    }

    public void animalShuffle()
    {
        int length = MeshLoader.transform.childCount;
        int selection = Random.Range(1,length);
        //Debug.Log(number);
        MeshFilter appearance = animalModel.GetComponent<MeshFilter>();
        //Destroy(appearance);
        
        MeshFilter newMesh = MeshLoader.transform.GetChild(selection).GetComponent<MeshFilter>();
        appearance.sharedMesh = newMesh.sharedMesh;
        
        adjustCollision();
    }
    public void adjustCollision()
    {
        BoxCollider collider = animalModel.GetComponent<BoxCollider>();
        Destroy(collider);
        animalModel.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        int number = Random.Range(1, 50);
        if(number == 1)
        {
            animalShuffle();
            //Debug.Log("SHUFFLING.");
        }
    }
}
