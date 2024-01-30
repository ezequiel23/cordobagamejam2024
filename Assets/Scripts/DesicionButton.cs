using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DesicionButton : MonoBehaviour
{

    public GameController Controller;
    public GameObject PanelOpciones;
    public string objetivo;

    public AudioSource audio;
    
    private Objetivo target;
    // Start is called before the first frame update
    void Start()
    {
        //EvilButton.onClick.AddListener(() => { this.Click(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickEvil()
    {
        // print($"{name} . {Controller == null}");
        Controller.nuevaVictima = true;
        PanelOpciones.SetActive(false);
        print("Click");
        target = GameObject.Find(objetivo).GetComponent<Objetivo>();
        target.aniMalo = true; 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audio.Play(0);
    }

    public void ClickGood()
    {
        // print($"{name} . {Controller == null}");
        Controller.nuevaBuenaAccion = true;
        PanelOpciones.SetActive(false); 
        print("Click");
        target = GameObject.Find(objetivo).GetComponent<Objetivo>();
        target.aniBuena = true; 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audio.Play(0);
        
    }

    public void SetObjetivo(string nombre){
        objetivo = nombre;
    }
}
