using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public float speed = 8f;
    Vector3 target;

    float activeTime = 10;
    Animator anim;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    bool muelto;
    bool isStartFalling;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!muelto)
        {
            if (Vector3.Distance(transform.position, target) > 0)
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            else
            {
                if (transform.position.x > 8 || transform.position.x < -8 || transform.position.y > 4 || transform.position.y < -4f)
                {
                    Destroy(this.gameObject);
                }

                SetTarget();

            }

            if (activeTime > 0)
                activeTime -= Time.deltaTime;

            UpdateSprite();
        }
        else
        {
            if (isStartFalling)
                transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up, 10*Time.deltaTime);
        }
        
        
    }

    public void Timeup()
    {
        speed *= 2;
        target = transform.position + new Vector3(0, 20, 0);
    }

    private void OnMouseDown()
    {
        if (!muelto)
            StartCoroutine(Dead());
        
    }

    IEnumerator Dead()
    {
        GameManager.Instance.HitDuck();
        muelto = true;
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(0.4f);
        isStartFalling = true;
        Destroy(gameObject, 3f);
    }

    public void UpdateSprite()
    {
        if (transform.position.x - target.x > 0)
        {
            transform.localScale = new Vector3(-5f, 5f, 5f);
        }
        else
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        }

        if (Mathf.Abs(transform.position.x - target.x) < 1)
        {
            anim.SetInteger("Fly", 2);
        }
        else if (Mathf.Abs(transform.position.y - target.y) < 1)
        {
            anim.SetInteger("Fly", 0);
        }
        else
        {
            anim.SetInteger("Fly", 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetTarget();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, target);
    }

    public void SetTarget()
    {
        if (activeTime > 0)
        { 
            target = target + new Vector3(Random.Range(-12, 12), Random.Range(-12, 12), 0);

            if (target.x > 6)
                target.x = 6;
            if (target.x < -6)
                target.x = -6;
            if (target.y > 4)
                target.y = 4;
            if (target.y < -2)
                target.y = -2;
        } 
    }
}
