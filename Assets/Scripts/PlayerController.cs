using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Ejes de movimientos")]
    private float horizontalInput;
    private float verticalInput;
    private Vector3 vectorMovement;


    [Header("Velocidad de movimiento")]
    public float speed = 5;
    public float runningSpeed = 10;

    [Header("Animación")]
    Animator animator;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // Movimiento
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        vectorMovement = new Vector3(horizontalInput, 0f, verticalInput);
        vectorMovement.Normalize();


        MovementAnimation();


        //Cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }



    void MovementAnimation()
    {
        if (horizontalInput == 0f && verticalInput == 0)
            animator.SetFloat("Walking", 0);
        else
        {
            // Caminar
            transform.Translate(vectorMovement * Time.deltaTime * speed);
            animator.SetFloat("Walking", 1);

            // Correr
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(vectorMovement * Time.deltaTime * runningSpeed);
                animator.SetBool("Running", true);
            }
            else
                animator.SetBool("Running", false);
        }
    }
}
