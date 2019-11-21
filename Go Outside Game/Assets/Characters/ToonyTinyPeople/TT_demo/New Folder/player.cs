using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float Speed;
    public double stamina = 100;
    public double health = 100;
    public double recover_rate = 0.2;
    public Slider stamina_bar;
    public Slider health_bar;
    public GameObject corpse;
    Animator m_Animator;
    public GameObject self;
    public GameObject body;



    // Update is called once per frame
    void Update()
    {
        stamina_bar.value = (int)(stamina);
        health_bar.value = (int)(health);
        playermovement();
        if (Input.GetKey(KeyCode.LeftShift) && stamina>=1)
        {
            Speed = 20;
            stamina -= 0.3;
           
            //Debug.Log(stamina);

        } else {
            Speed = 5;
           // Debug.Log(stamina);
            if (stamina< 100)
                stamina += recover_rate;
        }

        if(self.transform.position.y < -200)
        {
            self.transform.position = new Vector3(48 ,20,227);
        }

        if (health < 1)
        {
            player p = self.GetComponent<player>();
            corpse.transform.position = self.transform.position;
            corpse.SetActive(true);
            Rigidbody rigid = self.GetComponent<Rigidbody>();
            Destroy(rigid);
            Destroy(body);
            Destroy(p);
        }
    }
  
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }
    void playermovement() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(hor, 0f);
        bool hasVerticalInput = !Mathf.Approximately(ver, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        
    }
}
