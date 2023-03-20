using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D m_rb;
    GameController m_gc;
    public float speed;
    public float timeToDestroy;
    AudioSource aus;
    public AudioClip hitSound;
    public GameObject hitVFX;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Thay doi position 
        //Dung phuong thuc addForce của Component RigidBody2D
        //--
        //dùng vận tốc(velocity) trong Component RigidBody2D
        m_rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            m_gc.ScoreIncrement();
            if(aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }
            if (hitVFX)
            {
                Instantiate(hitVFX, collision.transform.position, Quaternion.identity);
                
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("SceneLimit"))
        {
            Destroy(gameObject);
        }
    }
    
}
