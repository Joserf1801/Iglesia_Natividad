using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalChamber : MonoBehaviour
{
    [SerializeField]
    private Camera floatCamera; 
    
    [Range (1,10)]
    public float velocidadDeRotacion=1;

    [Header("Zoom opciones")]
    public float distancia;
    public float zoomMax;
    public float zoomMin;
    
    private float anguloRotacion;    
    private Vector3 direccion;
    bool isActive;

    void Start()
    {
        //Inicializo mi evento
        ManagerEventos.EventoActivarModoAereo += ActivarModoAereo;

        //Obtengo la camara e inicializo las variables
        floatCamera = GetComponentInChildren<Camera>();
        floatCamera.enabled = false;
        anguloRotacion = 360;
        isActive = false;
    }
    void Update()
    {
        if (isActive)
        {
            RotarCamara();
            Zoom();
        }
          
    }

    public void RotarCamara(){

        if (Input.GetKey(KeyCode.A))
        {
            if (Mathf.Round(transform.eulerAngles.y) != anguloRotacion)
            {
                transform.Rotate(direccion * velocidadDeRotacion);
                direccion = transform.up;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Mathf.Round(transform.eulerAngles.y) != anguloRotacion)
            {
                transform.Rotate(-direccion * velocidadDeRotacion);
                direccion = transform.up;
            }
        }
    }

    public void Zoom()
    {
        float ScrollDato;
        ScrollDato = Input.GetAxis("Mouse ScrollWheel");

        if (ScrollDato < 0)
        {
            floatCamera.orthographicSize += distancia * Time.deltaTime;
        }
        if (ScrollDato > 0)
        {
            floatCamera.orthographicSize -= distancia * Time.deltaTime;
        }
        floatCamera.orthographicSize = Mathf.Clamp(floatCamera.orthographicSize, zoomMin, zoomMax);
    }

    public void ActivarModoAereo(bool enable)
    {
        floatCamera.enabled = enable;
        isActive = enable;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        floatCamera.orthographicSize = 13;
    }
}
