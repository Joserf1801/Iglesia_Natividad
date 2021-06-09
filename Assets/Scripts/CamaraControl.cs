using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    [SerializeField]private Transform jugador;
    public float sensibilidadX;
    public float sensibilidadY;
    private float rotacionX = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        ManagerEventos.EventoDesabilitarControles += OnDisable;
        ManagerEventos.EventoActivarControles += OnEnable;
       
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadY * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX,0f,0f);
        jugador.Rotate(Vector3.up * mouseX);
    }

    private void OnDisable()
    {
        GetComponent<CamaraControl>().enabled = false;
        ModoAereo(true);
    }

    private void OnEnable()
    {
        GetComponent<CamaraControl>().enabled = true;
        ModoAereo(false);
    }

    private void ModoAereo( bool enable )
    {
        ManagerEventos.DispararEventoActivarModoAereo(enable);
    }
}
