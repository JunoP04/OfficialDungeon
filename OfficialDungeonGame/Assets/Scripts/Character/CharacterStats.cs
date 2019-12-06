using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float health = 100.0f;
    public float strenghth = 20.0f;
    public float heartHealth = 100.0f;
    public int resources = 0;
    public string resourcesToString;

    //HUD elements
    public Slider healthBar;
    public Slider heartHealthBar;
    public Text resourceCounter;

    private void Start()
    {
        //Assigns HUD Elements to Character Stats
        //healthBar.value = health;
        //heartHealthBar.value = heartHealth;
        //resourceCounter.text = resources.ToString();
    }
}
