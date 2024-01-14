using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> 
{
    public float spawnTime;
    public Bird[] birds;
    public int timeLimit;

    int m_curtimeLimit;
    int m_birdKill;

    bool m_isGameover;

        
    public int BirdKill { get => m_birdKill; set => m_birdKill = value; }
    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }

    public override void Awake()
    {
        MakeSingleton(false);

        m_curtimeLimit = timeLimit;
    }

    public override void Start()
    {
        StartCoroutine(GameSpawn());
        StartCoroutine(TimeCountDown());
    }

    IEnumerator TimeCountDown()
    {
        while (m_curtimeLimit > 0)
        {
            yield return new WaitForSeconds(1f);

            m_curtimeLimit--;

            if(m_curtimeLimit <= 0 )
            {
                m_isGameover = true;
            }
        }
    }

    IEnumerator GameSpawn() //thuc hien cv nao do trong khoang thoi gian nhat dinh
    {
       while (!m_isGameover)
        {
            spawnBird() ;
            yield return new WaitForSeconds(spawnTime); //doi bao nhieu s de tao ra con chim tiep theo
        }
    }

    void spawnBird() //tao ra cac con chim xuat hien random
    {
        Vector3 spawnPos = Vector3.zero;

        float randCheck = Random.Range(0f, 1f);

        if(randCheck > 0.5f)
        {
            spawnPos = new Vector3(11, Random.Range(1f, 3f), 0);

        }else
        {
            spawnPos = new Vector3(-11, Random.Range(1f, 3f), 0);
        }

        if(birds !=null &&  birds.Length > 0)
        {
           int randIdx = Random.Range(0, birds.Length);

            if (birds[randIdx] != null)
            {
                Bird birdClone = Instantiate(birds[randIdx], spawnPos, Quaternion.identity);
            }
        }
    }
}
