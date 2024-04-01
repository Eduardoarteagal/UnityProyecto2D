using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject Jhon;
    public GameObject BulletEPrefab;
    public int Health = 1;
    private float LastShoot;
    private bool waitingToShoot = false;
    private float waitTime = 5.0f; 

    public float movimientoSpeed = 1.0f; 
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        if (Jhon == null) return;

        float moveDirection = Jhon.transform.position.x > transform.position.x ? 1f : -1f;
        rb.velocity = new Vector2(moveDirection * movimientoSpeed, rb.velocity.y);

        if (moveDirection > 0f) transform.localScale = new Vector3(1f, 1f, 1f);
        else transform.localScale = new Vector3(-1f, 1f, 1f);

        float distance = Mathf.Abs(Jhon.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f && !waitingToShoot)
        {
            StartCoroutine(WaitBeforeShoot());
        }
    }

    IEnumerator WaitBeforeShoot()
    {
        waitingToShoot = true;
        yield return new WaitForSeconds(waitTime);
        Shoot();
        LastShoot = Time.time;
        waitingToShoot = false;
    }

    private void Shoot()
    {
        Vector3 direction = transform.localScale.x > 0f ? Vector2.right : Vector2.left;

        GameObject bullet = Instantiate(BulletEPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hit();
            Destroy(collision.gameObject); // Destruye la bala
        }
    }

     public void Hit ()
    {
        Health = Health - 1;
        if (Health == 0) 
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("DerrotaGrunt");
            }
            movimientoSpeed = 0f;
            Destroy(gameObject);
        }
    }
}