using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerMovement PlayerHealth;
    public Image FillBar;
    private Slider slider;
    public Gradient gradasi;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float Fill = PlayerHealth.CurrentHealth;
        slider.value = Fill;
        FillBar.color = gradasi.Evaluate(slider.normalizedValue);
    }
}
