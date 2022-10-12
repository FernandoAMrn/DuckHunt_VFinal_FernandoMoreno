using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int ammo;
    //public int ammo;
    //public void WasteBullet(int bullet)
    //{
    //    ammo -= bullet;
    //    Debug.Log("Health= " + ammo.ToString());
    //}
    public void WasteABullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //PlayerAmmo playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
            //playerStats.WasteBullet(bull);
            --ammo;
        }

    }
}
