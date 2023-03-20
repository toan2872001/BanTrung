using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D m_rb;
    GameController m_gc;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
            m_gc.SetGameoverState(true);
            Debug.Log("Chạm vào Deathzone");
        }
    }
}
