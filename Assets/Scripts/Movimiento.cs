using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private CharacterController controller;
    public float velocidadMovimiento;
    public float velocidadSubirBajar;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ManagerEventos.EventoDesabilitarControles += OnDisable;
        ManagerEventos.EventoActivarControles += OnEnable;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        SubirBajar();
    }

    public void Mover()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movModificado = transform.right * h + transform.forward * v;
        controller.Move(movModificado * velocidadMovimiento * Time.deltaTime);
    }

    public void SubirBajar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float a = 0;
            a += 1;
            if (transform.position.y >= 30f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 30, transform.localPosition.z);
            }
            else
            {
                Vector3 movArriba = new Vector3(0, a, 0);
                controller.Move(movArriba * velocidadSubirBajar * Time.deltaTime);
            }        
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            float a = 0;
            a += 1;
            if (transform.position.y <=1)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 1, transform.localPosition.z);
            }
            else
            {
                Vector3 movAbajo = new Vector3(0, -a, 0);
                controller.Move(movAbajo * velocidadSubirBajar * Time.deltaTime);
            }
        }
    }

    private void OnDisable()
    {
        GetComponent<Movimiento>().enabled = false;
    }

    private void OnEnable()
    {
        GetComponent<Movimiento>().enabled = true;
    }
}
