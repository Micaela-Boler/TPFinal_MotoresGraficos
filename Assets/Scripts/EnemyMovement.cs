using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public float distanceToAttack = 2f;
    public float distanceToFollow = 500f;


    [Header("ANIMACION")]
    Animator animator;
    public EnemyHealth health;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (health.health != 0)
        {
            Destination(target);
            animator.SetFloat("Walking", 0.5f);


            if (Vector3.Distance(target.position, transform.position) <= distanceToAttack)
            {
                Destination(transform);

                animator.SetBool("Attack", true);
            }
            else
                animator.SetBool("Attack", false);
        }
        else
            Destination(transform);
    }



    public void Destination(Transform _transform)
    {
        agent.SetDestination(_transform.position);
    }


    //corrutina para ir a una posicion determinada (arreglo de posiciones)
    //Si el jugador se acerca mucho comienza a seguirlo
    //Si esta a una distancia muy cercana, deja de correr y ataca al objetivo
    //Si se aleja entonces deja de seguirlo u vuelve a iniciat la corrutina
}
