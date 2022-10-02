using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public bool isBurning = false;
    public bool isTakeBurningDamage = false;
    public GameObject fire;
    //Menerima Damage apabila health lebih dari 0
    public void DamagePoint(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            die();
        }
    }
    void Update()
    {
        if (isBurning == true)
        {
            if (isTakeBurningDamage == false)
            {
                isTakeBurningDamage = true;
                StartCoroutine(FireContinousDamage());

            }
        }
        else if(isBurning == false){
            isTakeBurningDamage = false;
        }
    }
    IEnumerator FireContinousDamage()
    {
        yield return new WaitForSeconds(0.2f);
        DamagePoint(1);
         isTakeBurningDamage =false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Destroy(other.gameObject);

             Debug.Log("Boom");
             DamagePoint(45);
            isBurning = true;
            StartCoroutine(onFire());
            
        }
    }


    IEnumerator onFire()
    {
        yield return new WaitForSeconds(3f);
         isBurning = false;
       
    }
    //Ketika health = 0, Die
    void die()
    {
        Destroy(gameObject);
    }
}