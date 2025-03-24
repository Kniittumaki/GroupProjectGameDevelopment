using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    [SerializeField] 
    private UnityEngine.UI.Slider slider;
 
    

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        slider.gameObject.SetActive(currentHealth < maxHealth);
        slider.value = currentHealth;
        slider.maxValue = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
