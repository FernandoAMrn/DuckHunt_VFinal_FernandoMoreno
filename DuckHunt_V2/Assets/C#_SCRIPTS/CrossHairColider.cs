using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairColider : MonoBehaviour
{
    public int Score; //Referencia para el score
    public GameObject deadDuck; //referencia para animacion de pato muerto
    public GameObject UIDuck; //referencia para el logo de pato en el UI
    public GameObject UIBullet; //referencia para el logo de las balas en el UI
    public Text ScoreText; //Texto de score
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject e = Instantiate(deadDuck) as GameObject;
        e.transform.position = transform.position;
        Destroy(other.gameObject); //Destruye el prefab de pato volando
        AddScore(); //Inicia la suma de score
        HideBullet();


    }

    void AddScore()
    {
        Score++;
        ScoreText.text = Score.ToString(); //Cambia de int a string.
    }

    void HideBullet()
    {
        //Esconde el UI de las balas.
    }
}
