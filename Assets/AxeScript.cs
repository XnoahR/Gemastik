using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
public Weapon AxeS;
public Transform Axe;
public Rigidbody2D Axerb;
    // Start is called before the first frame update
    void Start()
    {
        Axerb = Axe.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
   
            Debug.Log(other.collider.name);
            AxeS.IsInAir = false;
            Axerb.gravityScale = 0f;
        
    }
}
