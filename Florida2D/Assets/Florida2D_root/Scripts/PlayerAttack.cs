using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Stats")]
    public float attackCD;
    public float attackNormal;



    [SerializeField] GameObject attackCol;



    // Start is called before the first frame update
    void Start()
    {
        attackNormal = 1f;
        attackCol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCD >0) { attackCD -= Time.deltaTime; }
    }

   
    public void AttackOn(InputAction.CallbackContext context)
    {

        if (context.started && attackCD <= 0) 
        { 
            
            attackCol.gameObject.SetActive(true);
            attackCD = attackNormal;
            
        
        }

    }


    

}
