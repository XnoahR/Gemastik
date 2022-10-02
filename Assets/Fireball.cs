using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float SkillSpeed;
    public float fade;
    public Rigidbody2D fire;
    public Dummy dummy1;
    void Start()
    {
        fire =GetComponent<Rigidbody2D>();
        fire.velocity = transform.right*SkillSpeed*25*Time.fixedDeltaTime;
        Destroy(gameObject,fade);
    }


    // Update is called once per frame
     private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject){
            Destroy(gameObject);
        }
     }

}
