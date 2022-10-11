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
    public PlayerMovement PlayerS;
    public Transform WeaponSpawner;
    public float Cooldown;
    private float FireOn;
    
    //AxeScript
    public bool AxeMode = true;
    public bool IsCalled = false;
    public bool IsInAir = false;
    public bool IsDetectable;
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
            IsInAir = false;
            IsDetectable = false;
            AxeObj.gravityScale = 1;
            AxeObj.transform.parent = Player.transform;
            AxeObj.isKinematic = true;
    
            AxeObj.transform.position = WeaponContainer.transform.position;
        }

    if(IsInAir){
            AxeObj.transform.Rotate(0,0,15f,Space.Self);

    }
    else if(IsInAir == false){
        AxeObj.angularVelocity = 0f;
        AxeObj.velocity = Vector2.zero;
    }
        if(IsCalled == true){
            AxeObj.gravityScale = 0;
            AxeObj.transform.position = Vector2.MoveTowards(AxeObj.transform.position,Player.transform.position,CallSpeed*Time.deltaTime);
            IsInAir = true;
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
            AxeObj.transform.Rotate(0,0,5f,Space.Self);
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
        IsInAir = true;
       if(PlayerS.GetRight){
        AxeObj.AddForce(Vector2.right*ThrowSpeed);
       }
       else{
        AxeObj.AddForce(Vector2.left*ThrowSpeed);
       }
       StartCoroutine(DetectCD());
    }

    public void PickedUp(){
        Debug.Log("Picked Up");
        AxeObj.angularVelocity = 0f;
        if(PlayerS.GetRight){
    AxeObj.transform.rotation = Quaternion.Euler(0,180,30);
        }
        else{
             AxeObj.transform.rotation = Quaternion.Euler(0,0,30);

        }
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
    IEnumerator DetectCD(){
        yield return new WaitForSeconds(1f);
        IsDetectable = true;
    }
    
}
