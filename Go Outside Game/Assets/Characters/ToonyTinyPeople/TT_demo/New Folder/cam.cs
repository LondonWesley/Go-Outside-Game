using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float Rotationspeed;
    public Transform target, player;
    float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        camcontrol();
    }
    void camcontrol()
    {
        mouseX += Input.GetAxis("Mouse X") * Rotationspeed;
        mouseY -= Input.GetAxis("Mouse Y") * Rotationspeed;
        mouseY = Mathf.Clamp(mouseY, -40, 55);

        transform.LookAt(target);
        target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
