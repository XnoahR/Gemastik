using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirePoint;
    public GameObject Bullet;
    public float Cooldown;
    private float FireOn;

    // Update is called once per frame
    void Update()
    { 
        if (Time.time > FireOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireOn = Time.time + Cooldown;
                Shoot();
                
            }
        }
    }
     
    void Shoot(){
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}
