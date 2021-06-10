using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public AudioSource bocina;
    [Header("RecTransform")]
    public RectTransform panelOpciones;
    public RectTransform panelControles;
    public CanvasGroup imagen;
    public Sprite mutear;
    public Sprite noMutear;
    [Header("Botones")]
    public Button musica;
    [Header("Variables")]
    public bool abrir;
    public bool mute = false;
    public bool mostrarImg = false;
    public bool mostrarControles = false;

    private void Awake()
    {
        bocina = GetComponent<AudioSource>();
    }

    private void Start()
    {
        panelControles.gameObject.SetActive(false);
        imagen.gameObject.SetActive(false);
    }

    private void Update()
    {
        AbrirPanel();
    }

    public void AbrirPanel()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !abrir)
        {
            ManagerEventos.DispararEventoDesabilitarControles();
            Cursor.lockState = CursorLockMode.Confined;
            abrir = true;
            panelOpciones.DOAnchorPos(Vector2.zero, 0.25f);      
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1) && abrir)
        {
            ManagerEventos.DispararEventoActivarControles();
            Cursor.lockState = CursorLockMode.Locked;
            abrir = false;
            panelOpciones.DOAnchorPos(new Vector2(-170,0f), 0.25f);
            CerrarTodo();
        }
    }

    public void Informacion()
    {
        CerrarControles();
        CerrarCreditos();
        mostrarImg = !mostrarImg;
        if (mostrarImg)
        {
            imagen.gameObject.SetActive(true);
            imagen.alpha = 0;
            imagen.DOFade(1f, 0.8f);
        }
        else
        {
            CerrarInformacion();
        }
    }

    public void CerrarInformacion()
    {
        imagen.gameObject.SetActive(false);
        mostrarImg = false;
    }

    public void Controles()
    {
        CerrarInformacion();
        CerrarCreditos();
        mostrarControles = !mostrarControles;
        if (mostrarControles)
        {
            panelControles.gameObject.SetActive(true);
            panelControles.DOAnchorPos(new Vector2(380f, -12.30432f), 0.25f);
        }
        else
        {
            CerrarControles();
        }
        
    }

    public void CerrarControles()
    {
        panelControles.gameObject.SetActive(false);
        panelControles.DOAnchorPos(new Vector2(550f, -1040.226f), 0.25f);
    }

    public void Creditos()
    {
        ManagerEventos.DispararEventoDesabilitarControles(); 
    }

    public void CerrarCreditos()
    {

    }

    public void CerrarTodo()
    {
        CerrarControles();
        CerrarCreditos();
        CerrarInformacion();
    }

    public void MutearMusica()
    {
        mute = !mute;
        if (mute)
        {
            musica.image.sprite = mutear;
            bocina.mute = mute;
        }
        else
        {
            musica.image.sprite = noMutear;
            bocina.mute = mute;
        }
    }
}
