using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float tiempoMaximo = 120f;
    [SerializeField] float tiempoActual;
    [SerializeField] bool activadoTiempo;
    [SerializeField] Slider slider;

    public Manager manager;



    private void Start()
    {
        Activar();
    }


    void Update()
    {
        if (activadoTiempo)
            CambiarTimer();
    }



    void CambiarTimer()
    {
        tiempoActual -= Time.deltaTime;


        if (tiempoActual >= 0)
            slider.value = tiempoActual;

        if (tiempoActual <= 0)
        {
            manager.ChangeScene(3);
            EstadoDeTimer(false);
        }
    }



    void Activar()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;

        EstadoDeTimer(true);
    }


    public void EstadoDeTimer(bool estado)
    {
        activadoTiempo = estado;
    }

  
}
