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

    [Header("AUDIO")]
    [SerializeField] new AudioSource damageAudio;

    public Manager manager;




    void Start()
    {
        health = maxHealth;
        healthBar.StartHealth(health);
    }


    public void RecibirDaño(float damage)
    {
        health -= damage;

        healthBar.ChangeActualHealth(health);

        damageAudio.Play();


        if (health <= 0)
            manager.ChangeScene(3);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            RecibirDaño(1);
    }
}
