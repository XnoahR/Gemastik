using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    float HorizontalInput;
    [SerializeField] private string Nama = "RayDEV";
    public float speed;
    public bool Grounded = true;
    public LayerMask floor;
    public bool GetRight = true;
    public float JumpForce;
    public GameObject FP;
    public Transform feet;
    public float feetRange = 0.2f;
    public int DamagePoint = 10;
    public float CurrentHealth = 100;
    public int MaxHealth = 100;
    [SerializeField] private int JumpCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHealth = MaxHealth;

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(feet.position,feetRange,floor);
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity =new Vector2(HorizontalInput*speed*150*Time.fixedDeltaTime,rb.velocity.y);

            if(Grounded == true){
                JumpCount = 0;
            }
        if(Input.GetKeyDown(KeyCode.Space) && JumpCount == 0 ){
                jump();
                //JumpCount = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && JumpCount == 1){
            jump();
            //JumpCount = 2;
        }

        if(HorizontalInput > 0.01f && !GetRight){
            transform.localScale = Vector3.one;
           flip();
        }
        else if(HorizontalInput < -0.01f && GetRight){
            transform.localScale = new Vector3(-1,1,1);
            flip();
        }
     
    }

    void jump(){
        rb.velocity = new Vector2(rb.velocity.x,JumpForce*150*Time.fixedDeltaTime);
        JumpCount++;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "bullet"){
            Debug.Log("Attacked");
            damagePlayer(DamagePoint);
        
        }
    }
    void damagePlayer(int Damage){
           CurrentHealth = CurrentHealth - Damage;
                   if(CurrentHealth <= 0){
            SceneManager.LoadScene("MainMenu");
                }
    }
   

   void flip(){
       GetRight = !GetRight;
       FP.transform.Rotate(0,180,0);
   }

   private void OnDrawGizmosSelected() {
    if(feet == null){
        return;
    }

    Gizmos.DrawWireSphere(feet.position,feetRange);
   }
}
