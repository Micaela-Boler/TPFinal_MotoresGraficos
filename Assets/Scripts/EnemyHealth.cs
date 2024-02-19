using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("VIDA")]
    public float health;
    [SerializeField] float maxHealth;

    [Header("COLECCIONABLE")]
    [SerializeField] GameObject coin;

    [Header("ANIMACION")]
    Animator animator;

    [Header("AUDIO")]
    new AudioSource audio;



    void Start()
    {
        health = maxHealth;

        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }



    private void RecibirDa�o(float damage)
    {
        health -= damage;

        if (health <= 0)
            EnemyDeath();
    }



    private void EnemyDeath()
    {
        animator.SetBool("Death", true);

        Instantiate(coin, transform.position, Quaternion.identity);
        Destroy(gameObject, 2f);
    }



    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            RecibirDa�o(1);

            audio.Play();
            Destroy(collision.gameObject);
        }
    }
}
