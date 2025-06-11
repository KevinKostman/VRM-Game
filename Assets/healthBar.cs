using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public GameObject enemy;
    private Status status;
    public Slider healthBarSlider;
    public Slider easeHealthBarSlider;
    public float maxHealth = 100f;
    public float currentHealth;
    private float lerpSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        status = enemy.GetComponent<Status>();
        maxHealth = status.maxHealth;
        currentHealth = maxHealth;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;
        easeHealthBarSlider.maxValue = maxHealth;
        easeHealthBarSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = status.currHealth;
        maxHealth = status.maxHealth;
        if (healthBarSlider.value != currentHealth)
        {
            healthBarSlider.value = currentHealth;
        }
        if(healthBarSlider.value != easeHealthBarSlider.value)
        {
            easeHealthBarSlider.value = Mathf.Lerp(easeHealthBarSlider.value, currentHealth, lerpSpeed * Time.deltaTime);
        }

    }
}
