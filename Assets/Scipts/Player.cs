using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public GameObject projectile;
    public Transform shootingPoint;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip shootingSound;
    
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.isGameover())
            return;
        float xDir = Input.GetAxisRaw("Horizontal");
        if ((xDir < 0 && transform.position.x <= -8.5f) || (xDir > 0 && transform.position.x >= 8.5f))
            return;
        transform.position += Vector3.right * xDir * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    
    public void Shoot()
    {
        if (m_gc.isGameover())
            return;
        if (projectile && shootingPoint)
        {
            if(aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            m_gc.SetGameoverState(true);
            
        }
    }
    
}
