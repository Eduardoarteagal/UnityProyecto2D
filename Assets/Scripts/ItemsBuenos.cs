using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBuenos : MonoBehaviour
{
    public float cantidadPuntos;
    public Puntaje puntaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
        }
    }
}
