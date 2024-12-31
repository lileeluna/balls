using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;
    // Start is called before the first frame update


    // Update is called once per frame
    public void lossHealth(int damage)
    {
        healthAmount -= (damage);
        healthBar.fillAmount = healthAmount / 100f;
    }
}