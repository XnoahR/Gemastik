using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointHealth : MonoBehaviour
{
    public PlayerMovement Health;
    public Text Pointtxt;
    public Gradient ColorG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pointtxt.text = "" + Health.CurrentHealth;
    }
}
