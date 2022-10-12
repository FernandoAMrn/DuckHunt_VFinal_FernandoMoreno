using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI_SetActive : MonoBehaviour
{
    public Image[] bulletUI;
    PlayerAmmo playerAmmo;
    int ammo;
    // Start is called before the first frame update
    void Start()
    {
        playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAmmo>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // ammo = playerAmmo.ammo;

        switch (ammo)
        {
            case 3:
                foreach(Image img in bulletUI)
                {
                    img.gameObject.SetActive(true);
                }
                break;
            case 2:
                foreach (Image img in bulletUI)
                {
                    bulletUI[0].gameObject.SetActive(true);
                    bulletUI[1].gameObject.SetActive(true);
                    bulletUI[2].gameObject.SetActive(false);
                }
                break;
            case 1:
                foreach (Image img in bulletUI)
                {
                    bulletUI[0].gameObject.SetActive(true);
                    bulletUI[1].gameObject.SetActive(false);
                    bulletUI[2].gameObject.SetActive(false);
                }
                break;

            case 0:
                foreach (Image img in bulletUI)
                {
                    bulletUI[0].gameObject.SetActive(false);
                    bulletUI[1].gameObject.SetActive(false);
                    bulletUI[2].gameObject.SetActive(false);
                }
                break;
        }
    }
}
