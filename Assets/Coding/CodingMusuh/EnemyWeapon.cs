using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform Aim;
    public Transform Player;
    public GameObject Bullet;
   
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
       
    }

    public void Shoot()
    {
        Instantiate(Bullet, Aim.position, Aim.rotation);
    }
}
