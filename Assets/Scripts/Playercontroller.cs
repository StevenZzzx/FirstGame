using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb2D;
    Animator animator;
    public GameObject Bullet;
    
    [Header("Movimiento")]
    [SerializeField]private float velocidadDeMovimiento;
    [SerializeField] private float suavizadoDeMovimiento;
    private Vector3 movimiento = Vector3.forward;
    SpriteRenderer sr;


    [Header("Dash")]
    [SerializeField] private float distanciaDash;
    [SerializeField] private float duracionDash;
    [SerializeField] private float cooldownDash;
    [SerializeField] private TrailRenderer trailRenderer;
    private bool puedeHacerDash = true;
    private bool estaHaciendoDash = false;


    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical"); 

        if(movimiento.x > 0)
        {
            sr.flipX = false;
        }
        else if(movimiento.x < 0)
        {
            sr.flipX = true;
        }
        
        if(Input.GetButtonDown("Shift") && puedeHacerDash){

            StartCoroutine(Dash());
        }

    }

    void FixedUpdate() {
        
        if (!estaHaciendoDash)
        {
            Vector3 velocidadObjetivo = new Vector2(movimiento.x * velocidadDeMovimiento, movimiento.y * velocidadDeMovimiento);
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity,velocidadObjetivo,ref movimiento,suavizadoDeMovimiento);
        }
    }

    private IEnumerator Dash()
    {
        puedeHacerDash = false;
        estaHaciendoDash = true;
        rb2D.velocity = movimiento.normalized * distanciaDash / duracionDash;
        trailRenderer.emitting = true;

        yield return new WaitForSeconds(duracionDash);

        estaHaciendoDash = false;
        rb2D.velocity = Vector2.zero;
        trailRenderer.emitting = false;
        yield return new WaitForSeconds(cooldownDash);
        puedeHacerDash = true;
    }
}
