using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float speedb;

   // private bool col = false;
    void Update()
    {
        transform.Translate(Vector3.right * speedb * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")/* && !col*/)
        {

            speedb *= 1.5f;


            //col = true;
        }
    }
}
// Set the collided flag to true to avoid continuous speed changes
