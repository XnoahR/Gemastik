using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Rigidbody2D erb;
    public float WalkSpeed = 1;
    public Transform EnemyFeet;
    public LayerMask Air;
    public bool getflip = false;
    public bool Patrol;
    // Start is called before the first frame update
    void Start()
    {
        Patrol = true;
        erb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        getflip = Physics2D.OverlapCircle(EnemyFeet.position, 0.3f, Air);   
    }

    void FixedUpdate()
    {
        erb.velocity = new Vector2(WalkSpeed * 75 * Time.fixedDeltaTime, erb.velocity.y);

        if(getflip == true)
        {
            flip();
        }

    }

    void flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        WalkSpeed = WalkSpeed * -1;
    }
}
