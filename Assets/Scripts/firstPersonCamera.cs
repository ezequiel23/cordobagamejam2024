using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraScript : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float camaraVerticalRotation = 0f;

    //bool lockedCursor = true; 
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Capturo variables
        float inputX = Input.GetAxis("Mouse X")*mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;


        //Rotacion en eje Y
        camaraVerticalRotation -= inputY;
        camaraVerticalRotation = Mathf.Clamp(camaraVerticalRotation, -90f, 90f);

        transform.localEulerAngles = Vector3.right * camaraVerticalRotation;

        // ROtacion en eje x
        player.Rotate(Vector3.up * inputX);

    }
}
