using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("DISPARAR")]
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float force;

    [Header("COOLDOWN DE DISPARO")]
    public float fireRate;
    float timeToFire;

    [Header("ANIMACION")]
    Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (timeToFire <= 0 && Input.GetMouseButtonDown(0))
        {
            animator.SetBool("PlayerIsShooting", true);

            SHOOT();
            timeToFire = fireRate;
        }
            else
            {
                animator.SetBool("PlayerIsShooting", false);
                timeToFire -= Time.deltaTime;
            }
    }


    void SHOOT()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();
        bulletRB.AddRelativeForce(transform.forward * force, ForceMode.Impulse);

        Destroy(bulletClone, 5f);
    }
}
