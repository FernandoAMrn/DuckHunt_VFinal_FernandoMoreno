using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_Mov : MonoBehaviour
{
    
    public float speed = 10f;
    private Rigidbody2D rigBdy;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rigBdy = this.GetComponent<Rigidbody2D>();
        rigBdy.velocity = new Vector2(speed, 0);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x)
        {
            Destroy(this.gameObject);
        }
    }

    
}   
