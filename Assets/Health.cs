using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("VIDA")]
    [SerializeField] float health;
    [SerializeField] float maxHealth;

    [Header("BARRA DE VIDA")]
    [SerializeField] HealthBar healthBar;


    private new AudioSource audio;



    void Start()
    {
        health = maxHealth;
        healthBar.StartHealth(health);


        audio = GetComponent<AudioSource>();
    }



    public void RecibirDaño(float damage)
    {
        health -= damage;

        healthBar.ChangeActualHealth(health);

        if (health <= 0)
        {
            Debug.Log("Moriste");
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Enemy"))
            RecibirDaño(2);
    }
}
