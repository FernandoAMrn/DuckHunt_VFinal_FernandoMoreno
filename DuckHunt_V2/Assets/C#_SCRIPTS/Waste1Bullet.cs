using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste1Bullet : MonoBehaviour
{
    public int ammo;
    public int bullet;
    public void WasteABullet()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //PlayerAmmo playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
            //playerStats.WasteBullet(bull);
            -- bullet;
        }
        
    }
}
