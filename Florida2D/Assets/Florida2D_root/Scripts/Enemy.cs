using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    public int damage;
    public int takeDamage;

    [SerializeField] Image hpEnemy;
    public float enemyHealth;
    public float enemyMaxHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0) { enemyHealth = 0; }
        hpEnemy.fillAmount = enemyHealth / enemyMaxHealth;
        if (enemyHealth <= 0) { gameObject.SetActive(false); }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            enemyHealth -= takeDamage;
            collision.gameObject.SetActive(false);
        }
    }

}
