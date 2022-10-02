using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject bullet;
    public Transform FP;
    public bool isOnCooldown = false;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !isOnCooldown){
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay(){
        Instantiate(bullet,FP.position,FP.rotation);
        isOnCooldown = true;
        yield return new WaitForSeconds(2);
        isOnCooldown = false;
    }
}
