using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    [SerializeField] private Transform Controlador;
    [SerializeField] private GameObject bala;

    private void Update() {
        
        if (Input.GetButtonDown("Fire1"))
        {
            //Disparar
            Dispara();
        }

    }
    private void Dispara()
    {
        Instantiate(bala,Controlador.position,Controlador.rotation);
    }
}
