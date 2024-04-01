using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorAleatorio : MonoBehaviour
{
    public Transform pos;
    public GameObject[] objectsToInstantiate;

    void Start()
    {
        InstantiateObject();
    }

    private void InstantiateObject()
    {
        int n = Random.Range(0, objectsToInstantiate.Length); 
        GameObject newObj = Instantiate(objectsToInstantiate[n], pos.position, objectsToInstantiate[n].transform.rotation);

        // Comprueba qué tipo de objeto se ha instanciado
        if (newObj.CompareTag("Good"))
        {
            // Ejecuta los métodos correspondientes para los objetos buenos
            ItemsBuenos buenItemScript = newObj.GetComponent<ItemsBuenos>();
            if (buenItemScript != null)
            {
                buenItemScript.puntaje.SumarPuntos(buenItemScript.cantidadPuntos);
                Destroy(newObj);
            }
        }
        else if (newObj.CompareTag("Enemy"))
        {
            // Ejecutar métodos relacionados con el enemigo
            GruntScript gruntScript = newObj.GetComponent<GruntScript>();
            if (gruntScript != null)
            {
                // Obtener todos los métodos públicos del script GruntScript
                System.Reflection.MethodInfo[] methods = typeof(GruntScript).GetMethods();
                foreach (var method in methods)
                {
                    // Verificar que el método sea público y no sea especial (constructor, destructor, etc.)
                    if (method.IsPublic && !method.IsSpecialName)
                    {
                        // Invocar el método en el objeto GruntScript
                        method.Invoke(gruntScript, null);
                    }
                }
            }
        }
    }
}
