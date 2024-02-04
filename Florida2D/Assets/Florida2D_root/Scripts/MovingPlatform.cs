using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] float speed; //Velocidad de la plataforma
    [SerializeField] int startingPoint; //Numero para determinar la posicion de inicio de la plataforma
    [SerializeField] Transform[] points; // array de puntos que la plataforma va a perseguir
    int i;//indice del array que sirve para cambiar el transform que persigue la plataforma.




    // Start is called before the first frame update
    void Start()
    {
        //setear posicion inicial de la plataforma moviendola al punto de inicio
        transform.position = points[startingPoint].position;
    }



    // Update is called once per frame
    void Update()
    {
        PlatformMove();
    }



    void PlatformMove()

    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //sumar 1 al indice.Al cambiar el indice,cambia el objetivo a seguir
            if (i == points.Length) //chequea si el valor de i es igual a la longitud del Array
            {
                i = 0; // si lo es, el indice pasa a ser  0 para repetir la ruta

            }
        }
        //mueve plataforma a la posicion del punto guardado en el array que coincide con el valor de i, con la velocidad variable
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.y < collision.transform.position.y)
            {
                collision.gameObject.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
