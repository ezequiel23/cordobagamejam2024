using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objetivo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject PanelAccion;
    public GameObject PanelOpciones;
    private float distancia;
    public GameObject botonBueno;
    public GameObject botonMalo;
    public Animator animator;
    public TextMeshProUGUI cuadroTexto;

    public string mensaje;
    public string opcionBuena;
    public string opcionMala;
    public bool aniBuena;
    public bool aniMalo;

    public bool estado;
    private TextMeshProUGUI textoBotonBueno;
    private TextMeshProUGUI textoBotonMalo;
    void Start()
    {
        textoBotonBueno = botonBueno.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textoBotonMalo = botonMalo.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        if(distancia < 20f){
            if (!estado){
               PanelAccion.SetActive(!PanelOpciones.activeSelf);
                if(Input.GetKeyUp(KeyCode.E)){
                    PanelOpciones.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    // PanelAccion.SetActive(false);
                    cuadroTexto.text = mensaje;
                    textoBotonBueno.text = opcionBuena;
                    textoBotonMalo.text = opcionMala;
                    botonBueno.GetComponent<DesicionButton>().SetObjetivo(this.gameObject.name);
                    botonMalo.GetComponent<DesicionButton>().SetObjetivo(this.gameObject.name);
                    estado = true;
                    
                }
            }
        }else{
            PanelAccion.SetActive(false);
        }

        if (aniBuena){
            animator.SetTrigger("estaCaminando");
            
            aniBuena = false;
        }
        if (aniMalo){
            animator.SetTrigger("seCayo");
            aniMalo = false;
        }

    }
}
