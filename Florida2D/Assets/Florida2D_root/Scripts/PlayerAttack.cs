using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Stats")]
    
    [SerializeField] GameObject attackCol;



    // Start is called before the first frame update
    void Start()
    {
        
        attackCol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void Attack(InputAction.CallbackContext context)
    {
        attackCol.SetActive(true);
    }

}
