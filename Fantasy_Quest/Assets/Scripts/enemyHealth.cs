using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour
{
    public int startingHealth = 30;
    public int currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
    }
}
