using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem hpSystem = collision.gameObject.GetComponent<HealthSystem>();
            hpSystem.TakeDamage(damage);
        }
    }

}
