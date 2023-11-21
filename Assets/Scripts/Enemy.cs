using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private bool flip;
    public float speed;
        
    // Update is called once per frame
    private void Update()
    {
        //Rotation of the Enemy
        Vector3 scale = transform.localScale;
        if (Player.transform.position.x> transform.position.x){
            scale.x = Math.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(x:speed * Time.deltaTime, y:0, z:0);
        }

        else{
            scale.x = Mathf.Abs(scale.x) * 1 * (flip ? -1 : 1);
            transform.Translate(x:speed * Time.deltaTime * -1, y:0, z:0);
        }

        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         // Destroy the enemy and the bullet
        if (collision.CompareTag("Enemy"))
        {
        
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       
         if (collision.CompareTag("Ammo"))
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

}
