using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMoments : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    public float moveSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMove(InputValue value)//«öÁä®É±o¨ìvalue
    {
        moveInput = value.Get<Vector2>();
        if (moveInput == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            }
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed);
    }
    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }
    void OnDamage()
    {
        //animator.SetTrigger("isDamage");
    }
    void OnDie()
    {
        animator.SetTrigger("isDead");
    }
    #region Animation Method
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
