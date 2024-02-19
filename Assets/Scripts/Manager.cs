using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Score playerScore;
    public Timer timer;



    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Cursor.lockState = CursorLockMode.None;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerScore.puntos >= 10)
        {
            ChangeScene(2);
            timer.EstadoDeTimer(false);
        }
    }
}
