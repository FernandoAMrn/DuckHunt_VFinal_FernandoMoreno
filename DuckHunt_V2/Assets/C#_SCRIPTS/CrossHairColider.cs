using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairColider : MonoBehaviour
{
    public GameObject deadDuck;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject e = Instantiate(deadDuck) as GameObject;
        e.transform.position = transform.position;
        Destroy(other.gameObject);
    }
}
