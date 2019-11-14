using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float fullHealth;
    // public float resourceMaximum;
    public GameObject deathFX;

    float currentHealth;
    // float currentResource;


    //PlayerController controlMovement;

    //HUD Variables
    public Slider healthSlider;
    public Image damageBorder;
    public GameObject NextLevel;
    public GameObject RestartScreen;
    public GameObject gameoverScreen;


    bool damaged = false;
    Color damagedColour = new Color(0f, 0f, 0f, 0.5f);
    float SmoothColour = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
      //  controlMovement = GetComponent<PlayerController>();

        //HUD initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            MakeDead();
        }
        if (damaged)
        {
            damageBorder.color = damagedColour;
        }
        else
        {
            damageBorder.color = Color.Lerp(damageBorder.color, Color.clear, SmoothColour * Time.deltaTime); //Time.deltaTime
        }
        damaged = false;
    }
    public void AddDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        healthSlider.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }
    public void MakeDead()
    {
       // GameObject panel = gameOverScreen.GetComponent<GameObject>();
      //  gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
