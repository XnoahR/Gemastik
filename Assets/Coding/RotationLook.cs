
using UnityEngine;

public class RotationLook : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    Quaternion angle;

    float xpos;
    float pxpos;

   
    // Update is called once per frame
    void Update()
    {
         xpos = transform.position.x;
        pxpos = Player.position.x;
        
        Vector3 Target =  Player.position - transform.position;

           angle = Quaternion.LookRotation(Target, Vector3.forward);
    
        angle.x = 0.0f;
        angle.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 5);
    }
}
