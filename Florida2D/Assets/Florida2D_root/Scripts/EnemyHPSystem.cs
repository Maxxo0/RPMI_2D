using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPSystem : MonoBehaviour
{

    [SerializeField] Image hpEnemy;
    public float enemyHealth;
    public float enemyMaxHealth;



    // Start is called before the first frame update
    void Start()
    {
        if (enemyHealth <= 0) { enemyHealth = 0; }
        hpEnemy.fillAmount = enemyHealth / enemyMaxHealth;
        if (enemyHealth < 0) { gameObject.SetActive(false); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyTakeDamage(int playerDamage)
    {
        enemyHealth -= playerDamage;
    }
}
