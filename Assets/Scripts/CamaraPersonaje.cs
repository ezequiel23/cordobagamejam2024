using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CamaraPersonaje : MonoBehaviour
{    
    public float sensY;
    public float sensX;

    public Transform player;

    float xRotation;
    float yRotation;

 
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") + Time.deltaTime ;
        float mouseY = Input.GetAxis("Mouse Y") + Time.deltaTime ;

        xRotation += mouseX;
        yRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation,-90,90f);
        
        transform.rotation = Quaternion.Euler(yRotation,xRotation,0);
        player.rotation = Quaternion.Euler(0,xRotation,0);
        
    }
}
