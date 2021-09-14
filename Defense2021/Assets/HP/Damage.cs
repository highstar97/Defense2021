using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{

    public float StartHealth;
    public float Health;

    public GameObject HealthBar;

    public void GetDamage(int damage)
    {
        Health -= damage;
        HealthBar.GetComponent<Image>().fillAmount = Health / StartHealth;

    }
}
