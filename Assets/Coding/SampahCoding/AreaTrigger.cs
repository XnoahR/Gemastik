using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public Transform Player;
    public Transform Gun;
    public bool Activated = false;
    public GameObject Bullet;
    public Transform aim;
    public float Cooldown = 0.8f;
    public float OnFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated == true)
        {
            Vector2 Target = Player.position - Gun.position;
            Gun.transform.up = Target;
            if(Time.time > OnFire)
            {
                Shoot();
                OnFire = Time.time + Cooldown;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Activated = false;
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, aim.position, aim.rotation);
    }
}
