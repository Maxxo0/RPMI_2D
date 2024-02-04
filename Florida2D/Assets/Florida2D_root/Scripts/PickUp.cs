using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

    public int takeDamage;

    [SerializeField] Image hpPickUp;
    [SerializeField] Canvas canvasPickUp;
    [SerializeField] GameObject dropPrefab;
    [SerializeField] GameObject dropPoint;
    public float pickUPHealth;
    public float pickUpMaxHealth;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUPHealth <= 0) { pickUPHealth = 0; }
        hpPickUp.fillAmount = pickUPHealth / pickUpMaxHealth;
        if (pickUPHealth <= 0) 
        {
            Instantiate(dropPrefab, dropPoint.transform.position, Quaternion.identity);
            gameObject.SetActive(false); 
        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            canvasPickUp.gameObject.SetActive(true);
            pickUPHealth -= takeDamage;
            collision.gameObject.SetActive(false);
        }
    }

}
