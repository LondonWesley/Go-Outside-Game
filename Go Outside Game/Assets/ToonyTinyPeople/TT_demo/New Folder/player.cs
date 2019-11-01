using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Speed;
    Animator m_Animator;



    // Update is called once per frame
    void Update()
    {
        playermovement();
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
