using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagerEventos
{
    public static event Action EventoDesabilitarControles = delegate { };

    public static void DispararEventoDesabilitarControles()
    {
        EventoDesabilitarControles();
    }

    public static event Action EventoActivarControles = delegate { };

    public static void DispararEventoActivarControles()
    {
        EventoActivarControles();
    }


    //Modo aereo
    public static event Action <bool>EventoActivarModoAereo = delegate { };

    public static void DispararEventoActivarModoAereo( bool enable )
    {
        EventoActivarModoAereo(enable);
    }
}
