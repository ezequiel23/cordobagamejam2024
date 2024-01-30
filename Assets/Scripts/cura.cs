using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cura : MonoBehaviour
{
    public Transform goal;
    
    public GameController gameController;
    public Animator animator;
    public float velocidad;
    Vector3 destination;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        destination =goal.position;
        agent.speed =  gameController.victimasMaldad * 2 * velocidad;
        if (gameController.victimasMaldad > 0 ){
            animator.SetTrigger("estaCaminando");
            if (gameController.victimasMaldad > 1){
                animator.SetTrigger("estaCorriendo");
            }else{
                animator.ResetTrigger("estaCorriendo");
            }
            
        }else{
            animator.ResetTrigger("estaCaminando");
        }
        agent.destination = destination; 
        
    }
}
