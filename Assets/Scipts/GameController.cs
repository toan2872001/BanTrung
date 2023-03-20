using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;

    public float spawnTime;
    float m_spawntime;
    int m_score;
    bool m_isGameover;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawntime = 0;
        m_ui = FindAnyObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            m_spawntime = 0;
            m_ui.ShowGameoverPannel(true);
            return;
        }
        m_spawntime -= Time.deltaTime;
        if (m_spawntime <= 0)
        {
            SpawnEnemy();

            m_spawntime = spawnTime;
        }
        
    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-8f, 8f);
        Vector2 spawnPos = new Vector2(randXpos, 7f);
        if (Enemy)
        {
            Instantiate(Enemy, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        if (m_isGameover)
            return;
        m_score++;
        m_ui.SetScoreText("Score : " + m_score);
    }
    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    public bool isGameover()
    {
        return m_isGameover;
    }
}
