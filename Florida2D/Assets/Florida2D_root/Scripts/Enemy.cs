using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    public int damage;
    public int takeDamage;
    private float distance;
    public float speed; //Velocidad 
    

    [SerializeField] Image hpEnemy;
    [SerializeField] Canvas canvasEnemy;
    public float enemyHealth;
    public float enemyMaxHealth;
    [SerializeField] int startingPoint; //Numero para determinar la posicion 
    [SerializeField] Transform[] points; // array de puntos que la plataforma va a perseguir
    Rigidbody2D rbTurtle; // maybe
    
    Animator turtleAnimator;

    public int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;
        turtleAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) { enemyHealth = 0; }
        hpEnemy.fillAmount = enemyHealth / enemyMaxHealth;
        if (enemyHealth <= 0) { gameObject.SetActive(false); }
        Move();
        

    }


    /* private void OnTriggerEnter2D(Collider2D collision)
     {

         if (collision.gameObject.CompareTag("Player"))
         {

             HealthSystem hpSystem = collision.gameObject.GetComponent<HealthSystem>();
             hpSystem.TakeDamage(damage);
             gameObject.SetActive(false);
         }
     }
    */



    void Move()

    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //sumar 1 al indice.Al cambiar el indice,cambia el objetivo a seguir
            if (i == points.Length) //chequea si el valor de i es igual a la longitud del Array
            {
                i = 0; // si lo es, el indice pasa a ser  0 para repetir la ruta

            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        /*
        transform.rotation = Quaternion.Euler(0, 180, 0);
        distance = Vector2.Distance(transform.position, Player.transform.position) ;
        transform.position = Vector2.MoveTowards(this.transform.position, points[i].position, speedboost * Time.deltaTime);*/
        if (i == 1) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        if (i == 0) { transform.rotation = Quaternion.Euler(0, 180, 0); }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem hpSystem = collision.gameObject.GetComponent<HealthSystem>();
            hpSystem.TakeDamage(damage);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            canvasEnemy.gameObject.SetActive(true);
            enemyHealth -= takeDamage;
            collision.gameObject.SetActive(false);
        }
    }

}
