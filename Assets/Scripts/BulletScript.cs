using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection (Vector2 direction)
    {
        Direction = direction;
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JohnMovement john = collision.gameObject.GetComponent<JohnMovement>();
        GruntScript grunt = collision.gameObject.GetComponent<GruntScript>();
    
        if (john != null)
        {
            john.Hit();
        }
        if (grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }
}
    //metodo para cuando dispare mueva al objeto
    /*private void OnCollisionEnter2D (Collision2D collision)
    {
        JohnMovement jhon = collision.collider.GetComponent<JohnMovement>();
        GruntScript grunt = collision.collider.GetComponent<GruntScript>();
        if (jhon != null)
        {
            jhon.Hit();
        }
        if (grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }*/

