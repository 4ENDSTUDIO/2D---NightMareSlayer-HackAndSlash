﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public static float maxHealth = 100f;
    public static float health;
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    public void healthGlobal()
    {
        maxHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }
}
