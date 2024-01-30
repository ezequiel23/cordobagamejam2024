using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    //Ui user
    public ProgressBar progressBar;

    // booleanos transicion estados
    public bool visionNublada {  get; set; }
    public bool sonidosMolestos {  get; set; }
    public int victimasMaldad = 0;
    public bool nuevaVictima { get; set; }
    public int buenasAcciones = 0;
    public bool nuevaBuenaAccion {  get; set; }


    public AudioSource latido;
    //Booleans condicion victoria/derrota
    bool gano = false;
    bool perdio = false;

    public GameObject casa;
    public GameObject player;
    public GameObject panelRisas;
    public Texture frame1;
    public Texture frame2;
    public Texture frame3;
    public Texture frame4;
    private float distancia;
    // Start is called before the first frame update
    void Start()
    {
        visionNublada = false;
        sonidosMolestos = false;
        nuevaVictima = false;
        nuevaBuenaAccion = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if(gano || perdio)
        {
            EndGame();
        }

        if(nuevaVictima)
        {
            nuevaVictima = false;
            victimasMaldad++;
            visionNublada=false;
            sonidosMolestos=false;
            buenasAcciones=0;
            AumentarBarraLocura(20);
            latido.Play(0);
            panelRisas.SetActive(true);
            if (victimasMaldad == 1){
                panelRisas.GetComponent<UnityEngine.UI.RawImage>().texture = frame2;
            }else if(victimasMaldad == 2){
                panelRisas.GetComponent<UnityEngine.UI.RawImage>().texture = frame4;
            }
            
        }

        if (nuevaBuenaAccion)
        {
            nuevaBuenaAccion = false;
            buenasAcciones++;
            visionNublada = true;
            sonidosMolestos = true;
            victimasMaldad = 0;
            DisminuirBarraLocura(15);
            latido.Pause();
            panelRisas.SetActive(false);
        }
        // se procesan los estados modificados por las acciones
        //ProcesarEstadosAlterados();
        distancia = Vector3.Distance(casa.transform.position, player.transform.position);
        // Debug.Log(distancia);
        if (distancia < 50f){
            gano = true;
        }
    }

    private void ProcesarEstadosAlterados()
    {
        if (visionNublada)
        {
            NublarVision();
        }
        else
        {
            VisionNormal();
        }

        if (sonidosMolestos) 
        {
            PrenderSonidos();
        }
        else
        {
            ApagarSonidos();
        }
    }

    private void VisionNormal()
    {
        throw new NotImplementedException();
    }

    private void NublarVision()
    {
        throw new NotImplementedException();
    }

    private void ApagarSonidos()
    {
        throw new NotImplementedException();
    }

    private bool PrenderSonidos()
    {
        throw new NotImplementedException();
    }



    // End game 
    private void EndGame()
    {
        if (gano)
        {
            Ganar();
        }
        if (perdio)
        {
            Perder();
        }
    }

    void Ganar()
    {
        Debug.Log("GANO");
        SceneManager.LoadScene("Gano");
    }

    void Perder()
    {

    }

    // Manejo Barra Locura
    void AumentarBarraLocura(int value)
    {
        progressBar.AumentarBarra(value);
    }
    void DisminuirBarraLocura(int value)
    {
        progressBar.DisminuirBarra(value);
    }
}
