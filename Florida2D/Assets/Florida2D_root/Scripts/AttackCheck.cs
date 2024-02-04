using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{

    public float attackTime;
    public float attackTimeReset;

    // Start is called before the first frame update
    void Start()
    {
        attackTime = 1f;
        attackTimeReset = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime > 0) { attackTime -= Time.deltaTime; }

        if (attackTime <= 0) 
        {
            attackTime = attackTimeReset;
            gameObject.SetActive(false); 
        }
    }
}
