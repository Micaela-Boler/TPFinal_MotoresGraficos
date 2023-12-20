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

    //[Header("AUDIO")]
    //new AudioSource audio;

    [Header("ANIMACION")]
    Animator animator;



    void Start()
    {
        //audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            TimeToShoot();
        else
            animator.SetBool("PlayerIsShooting", false);
    }



    void TimeToShoot()
    {
        if (timeToFire <= 0f)
        {
            SHOOT();

            timeToFire = fireRate;
        }
        else 
            timeToFire -= Time.deltaTime;
    }


    void SHOOT()
    {
        animator.SetBool("PlayerIsShooting", true);

        GameObject bulletClone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();
        bulletRB.AddRelativeForce(transform.forward * force, ForceMode.Impulse);

        // audio.Play();
        Destroy(bulletClone, 5f);
    }
}
