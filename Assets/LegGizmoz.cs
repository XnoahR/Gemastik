using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    

public class LegGizmoz : MonoBehaviour
{
    public PlayerMovement PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected() {
        if(transform == null){
            return;
        }
        Gizmos.DrawWireSphere(transform.position,PlayerScript.feetRange);
    }
}
