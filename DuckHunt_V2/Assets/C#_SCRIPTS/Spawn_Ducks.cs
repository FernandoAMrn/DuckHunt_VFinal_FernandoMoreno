using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Ducks : MonoBehaviour
{
    public GameObject DuckPrefab;
    public float instntiateEveryXSec = 1.0f;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(duckWave());
    }

    
    public void SpawnDuck()
    {
        //Instanciar el prefab del pato
        GameObject a = Instantiate(DuckPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }


    IEnumerator duckWave(){
        while (true){
            yield return new WaitForSeconds(instntiateEveryXSec);
            SpawnDuck();
        }
        
    }
}
