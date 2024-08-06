using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableChracter : MonoBehaviour,iDamageable
{
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health <= 0)
            {
                gameObject.BroadcastMessage("OnDie");
                Targetable = false;
            }
            else
            {
                gameObject.BroadcastMessage("OnDamage");
            }
        }
    }
    bool targetable;
    public bool Targetable
    {
        get
        {
            return targetable;
        }
        set
        {
            targetable = value;
            if (!targetable)
            {
                rb.simulated = false;
            }
        }
    }
    public void OnHit(int damage, Vector2 knockback)
    {
        Health -= damage;
        rb.AddForce(knockback);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
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
