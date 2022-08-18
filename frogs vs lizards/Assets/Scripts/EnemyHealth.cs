using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;

    public Image healthBar;
    public void takeDamage(float amount)
    {

        health -= amount;

        healthBar.fillAmount = health /100f;

        if (health == 0)
        {

            die();

        }

    }

    public void die()
    {

        Destroy(gameObject);

    }

}
