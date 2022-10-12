using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform[] spwanPoints;
    public GameObject duckPrefab;
    public SpriteRenderer bg;
    public Color blueColor;

    public GameObject dogMiss, dogHit;
    public SpriteRenderer dogSprite;
    public Sprite[] victorySprites;

    public Text roundText;
    int roundNumber = 1;
    int totalTrials = 10;

    public int totalHits;
    int ducksCreated;
    bool isRoundOver;

    public Text scoreText, hitsText;
    int score, hits, totalClicks;

    public GameObject[] duckUI;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            totalClicks++;

        scoreText.text = score.ToString("000");
        hitsText.text = hits.ToString() + "/" + totalClicks.ToString();
    }

    public void CallCreateDucks()
    {
        StartCoroutine(CreateDucks(2));
    }

    IEnumerator CreateDucks(int _count)
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < _count; i++)
        {
            GameObject _duck = Instantiate(duckPrefab, spwanPoints[Random.Range(0, spwanPoints.Length)].position, Quaternion.identity);
            ducksCreated++;

            
            
            


        }

        StartCoroutine(TimeUp());
    }
    [SerializeField]
    private Color colorToTurnTo = Color.red;

    IEnumerator TimeUp()
    {
        yield return new WaitForSeconds(10f);
        Duck[] ducks = FindObjectsOfType<Duck>();
        for (int i = 0; i < ducks.Length; i++)
        {
            ducks[i].Timeup();
        }
        bg.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        bg.color = blueColor;
        if (!isRoundOver)
            StartCoroutine(RoundOver());
    }

    public void HitDuck()
    {
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        totalHits++;
        score += 10;
        hits++;
        bg.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        bg.color = blueColor;
        ducksCreated--;

        if (ducksCreated <= 0)
        {
            if (!isRoundOver)
            {
                StopCoroutine(TimeUp());
                StartCoroutine(RoundOver()); 
            }
        }
        
    }

    IEnumerator RoundOver()
    {
        isRoundOver = true;
        duckUI[1].SetActive(false);
        yield return new WaitForSeconds(1f);

        if (ducksCreated <= 0)
        {
            dogHit.SetActive(true);
            dogSprite.sprite = victorySprites[0];
            
        }
        else if (ducksCreated == 1)
        {
            dogHit.SetActive(true);
            dogSprite.sprite = victorySprites[1];
            
        }
        else 
        {
            dogMiss.SetActive(true);
        }

        yield return new WaitForSeconds(2f);
        dogHit.SetActive(false);
        dogMiss.SetActive(false);
        CallCreateDucks();
        isRoundOver = false;
        
        
    }
}
