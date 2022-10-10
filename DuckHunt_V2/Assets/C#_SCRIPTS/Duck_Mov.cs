using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_Mov : MonoBehaviour
{
    public float speed;
    Vector3 target;

    float lifespan = 10;
    Animator anim;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2d;
    bool muerto;
    bool caida;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            if (Vector3.Distance(transform.position, target) > 0)
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            else
            {
                if (transform.position.x > 8 || transform.position.x < -8 || transform.position.y > 4)
                {
                    Destroy(gameObject);
                }

                SetTarget();
            }

            if (lifespan > 0)
                lifespan -= Time.deltaTime;

            UpdateSprite();
        }
    }
}
