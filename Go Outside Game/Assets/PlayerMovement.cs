using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController charCtrl;

    public float speed = 20f;

    public float gravity = -9.8f;
    Vector3 velocity;
    public float mass = 10;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charCtrl.Move(move * speed * Time.deltaTime);

        if (!charCtrl.isGrounded)
        {
            velocity.y += (gravity* mass) * Time.deltaTime;
            charCtrl.Move(velocity * Time.deltaTime );
        } else
        {
            velocity.y = 0;
        }



    }
}
