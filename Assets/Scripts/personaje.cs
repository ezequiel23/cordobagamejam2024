using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class personaje : MonoBehaviour
{
    public float velocidad;
    public GameObject PanelOpciones;
    Vector3 destination;
    // private CharacterController controller;
    private NavMeshAgent player;
    private Vector3 move;
    private Vector3 newPos;
    public Transform cura;
    private float yRotation; 
    
    private float distancia;
    // Start is called before the first frame update
    void Start()
    {
           
        // controller = GetComponent<CharacterController>();
        
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (PanelOpciones.activeSelf){
            velocidad = 0f;
        }else{
            velocidad = 30.0f;
        }
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        // move = new Vector3(moveX,0,moveY);
        // newPos = transform.position + move;
        yRotation = transform.rotation.eulerAngles.y;
        // Debug.Log(yRotation);
        if ((yRotation >= 270f && yRotation <= 360f) || (yRotation >= 0f && yRotation < 45f) ){
           move = new Vector3(moveX,0,moveY);

        }else if((yRotation >= 45f && yRotation < 135f)){
            move = new Vector3(moveY,0,-moveX);
            
        }else if((yRotation >= 135f && yRotation < 225f)){
            move = new Vector3(-moveX,0,-moveY);
            
        }else if((yRotation >= 225f && yRotation < 270f)){
            move = new Vector3(-moveY,0,moveX);
            
        }
        newPos = transform.position + move;
        player.Move(move * Time.deltaTime * velocidad ); 
        distancia = Vector3.Distance(cura.transform.position, transform.position);
        Debug.Log(distancia);
        if (distancia < 10f){
            SceneManager.LoadScene("Perdio");
        }
    }
}
