using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [Header("PUNTOS")]
    public int puntos;
    [SerializeField] TextMeshProUGUI puntosInterfaz;

    [Header("AUDIO")]
    public new AudioSource audio;



    void Start()
    {
        updateScore();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            puntos++;
            updateScore();

            audio.Play();
            Destroy(other.gameObject);
        }
    }


    void updateScore()
    {
        puntosInterfaz.text = puntos.ToString() + "/" + "10";
    }
}
