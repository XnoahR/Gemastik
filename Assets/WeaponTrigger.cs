using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    public Weapon AxeTrigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Axe")
        {
            if (AxeTrigger.IsDetectable == true)
            {
                if (AxeTrigger.AxeMode == false)
                {
                    AxeTrigger.PickedUp();
                }
            }
        }
    }
}
