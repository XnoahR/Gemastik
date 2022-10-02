using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public Rigidbody2D bullet;
    public float Explode = 2f;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = transform.right*BulletSpeed*150*Time.deltaTime;
        Destroy(gameObject, Explode);

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Hit)
    {
        //Damage System
        Dummy dummy = Hit.GetComponent<Dummy>();
        if(dummy != null){
            dummy.DamagePoint(10);
        }
            Destroy(gameObject);
    }
}
