using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnPlataforma : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float velocidadDeMovimiento;
    public LayerMask capaAbajo;
    public LayerMask capaEnFrente;
    public float distanciaAbajo;
    public float distanciaEnFrente;
    public Transform controladorAbajo;
    public Transform controladorEnFrente;
    public bool informacionAbajo;
    public bool informacionEnFrente;
    private bool mirandoALaDerecha = true;

    private void Update()
    {
        rb2D.velocity = new Vector2(velocidadDeMovimiento, rb2D.velocity.y);
        informacionEnFrente = Physics2D.Raycast(controladorEnFrente.position, transform.right, distanciaEnFrente, capaEnFrente);
        informacionAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);
        if (informacionEnFrente || !informacionAbajo)
        {
            Girar();
        }
    }
    private void Girar()
    {
        mirandoALaDerecha = !mirandoALaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidadDeMovimiento *= -1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorAbajo.position, controladorAbajo.position + transform.up * -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorEnFrente.position, controladorEnFrente.position + transform.right * distanciaEnFrente);
    }

}
