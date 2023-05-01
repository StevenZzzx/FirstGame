using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float Speed = 10f;
    public int Damage = 10;
    public float tiempoDeVida = 2f;
    private float tiempoDeVidaActual = 0f;

    private Rigidbody2D rb;

    private void Start() 
    {
        tiempoDeVidaActual = tiempoDeVida;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * Speed;
    }
    private void Update() 
    {
        tiempoDeVidaActual -= Time.deltaTime;
        if (tiempoDeVidaActual <= 0f) {
            Destruir();
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.CompareTag("Enemigo")){

    //         other.GetComponent<Enemigo>().GetDamage(Damage);
    //         Destroy(gameObject);
    //     }
    // }
    void Destruir () {
        Destroy(gameObject);
    }
}
