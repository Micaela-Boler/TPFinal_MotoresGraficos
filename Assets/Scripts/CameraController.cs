using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 anguloDeCamara;
    Vector2 suavidadMovimiento;

    public float sensibilidad = 5;
    public float suavizado = 2;

    [SerializeField] GameObject player;


    void Update()
    {
        // Toma la entrada del mouse en X e Y
        var direccionMouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        direccionMouse = Vector2.Scale(direccionMouse, new Vector2(sensibilidad * suavizado, suavizado * sensibilidad));

        //  Aplica suavizado a los valores de entrada para evitar movimientos bruscos
        suavidadMovimiento.x = Mathf.Lerp(suavidadMovimiento.x, direccionMouse.x, 1f / suavizado);
        suavidadMovimiento.y = Mathf.Lerp(suavidadMovimiento.y, direccionMouse.y, 1f / suavizado);

        // Actualiza la variable "anguloDeCamara" sumando los valores suavizados.
        anguloDeCamara += suavidadMovimiento;

        // Limita la rotación vertical para evitar que la cámara gire más allá de 90 grados hacia arriba o abajo.
        anguloDeCamara.y = Mathf.Clamp(anguloDeCamara.y, -90f, 90f);


        transform.localRotation = Quaternion.AngleAxis(-anguloDeCamara.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(anguloDeCamara.x, player.transform.up);
    }
}
