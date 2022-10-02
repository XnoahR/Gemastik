using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeArea : MonoBehaviour
{

    public Transform Player;
    public Transform Slime;
    public bool Detected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Detected == true)
        {
            Vector2 Range = Player.position - Slime.position;
            Slime.transform.forward = Range;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Detected = false;
        }
    }
}
