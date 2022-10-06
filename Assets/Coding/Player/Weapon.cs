using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirePoint;
    public GameObject Bullet;
    public GameObject WeaponContainer;
    public GameObject Player;
    public Transform WeaponSpawner;
    public float Cooldown;
    private float FireOn;
    
    //AxeScript
    public bool AxeMode = true;
    public bool IsCalled = false;
    public Transform AxeT;
    public Rigidbody2D AxeObj;
    public float ThrowSpeed;
    public float CallSpeed;
        IEnumerator Status;

    // Update is called once per frame
    void Start() {
        AxeObj = AxeObj.GetComponent<Rigidbody2D>();
                Status = Spawn();

    }
    void Update()
    { 
        if(AxeMode == true){
            IsCalled = false;
            AxeObj.gravityScale = 1;
            AxeObj.transform.parent = Player.transform;
            AxeObj.isKinematic = true;
            AxeObj.transform.rotation = Quaternion.Euler(0,0,50);
            AxeObj.transform.position = WeaponContainer.transform.position;
        }

        if(IsCalled == true){
            AxeObj.gravityScale = 0;
            AxeObj.transform.position = Vector2.MoveTowards(AxeObj.transform.position,Player.transform.position,CallSpeed*Time.deltaTime);
        }
        if (Time.time > FireOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireOn = Time.time + Cooldown;
                Shoot();
                
            }
        }

        if(Input.GetMouseButtonDown(1) && AxeMode == true){
            ThrowAxe();
        }
        if(Input.GetKeyDown(KeyCode.L) && AxeMode == false && IsCalled == false){
            AxeObj.velocity = Vector2.zero;
            CallAxe();
            StartCoroutine(Spawn());
        }

        
    }
     
    void Shoot(){
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }

    void ThrowAxe(){
        AxeObj.isKinematic = false;
        AxeObj.transform.parent = null;
        AxeMode = false;
        AxeObj.AddForce(Vector2.right*ThrowSpeed);
    }

    public void PickedUp(){
        Debug.Log("Picked Up");
        AxeMode = true;
    StopCoroutine(Spawn());

    }
    void CallAxe(){
        IsCalled = true;
    }
    IEnumerator Spawn(){
        
        yield return new WaitForSeconds(4f);
       // Debug.Log(Spawn());
       if(AxeMode == true){
        Debug.Log("Stopped");
       }
       else if(AxeMode == false){
    AxeObj.transform.position =WeaponSpawner.transform.position;
    Debug.Log("Spawned");
       }
    }
}
