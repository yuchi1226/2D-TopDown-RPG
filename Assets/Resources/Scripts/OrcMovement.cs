using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    DetectionZone detectionZone;
    Animator animator;

    public float speed;
    public float knockbackForce;
    public int attactPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectionZone = GetComponent<DetectionZone>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (detectionZone.detectedObjs != null)
        {
            Vector2 direction = (detectionZone.detectedObjs.transform.position - transform.position);//�p�ǫ��V���a���V�q
            if (direction.magnitude <= detectionZone.viewRadius)
            {
                rb.AddForce(direction.normalized * speed);
                if (direction.x > 0)//���V�k��
                {
                    spriteRenderer.flipX = false;
                }
                if (direction.x < 0)//���V����
                {
                    spriteRenderer.flipX = true;
                }
                OnWalk();
            }
            else
            {
                OnWalkStop();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        iDamageable damageable = collider.GetComponent<iDamageable>();
        if (damageable != null && collider.tag == "Player")
        {
            Vector2 direction = collider.transform.position - transform.position;
            Vector2 force = direction.normalized * knockbackForce;
            
            damageable.OnHit(attactPower, force);//��h����q
        }
    }
    public void OnWalk()
    {
        animator.SetBool("isWalking", true);
    }
    public void OnWalkStop()
    {
        animator.SetBool("isWalking", false);
    }
    void OnDamage()
    {
        animator.SetTrigger("isDamage");
    }
    void OnDie()
    {
        animator.SetTrigger("isDead");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
