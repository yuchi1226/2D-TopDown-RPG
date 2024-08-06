using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    Vector3 position;
    private int attackPower;//�����O
    public int knockbackForce;//�u�}��誺�O��

    // Start is called before the first frame update
    void Start()
    {
        position = transform.localPosition;
    }
    void IsFacingRight(bool isFacingRight)
    {
        if (!isFacingRight)
        {
            transform.localPosition = position;
        }
        else
        {
            transform.localPosition = new Vector3(-position.x, position.y, position.z);
            //transform.localPosition = position;
            //transform.localEulerAngles = new Vector3(0, 180, 0);  // Y�b����180��
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        iDamageable damageable = collider.GetComponent<iDamageable>();

        if (damageable != null)
        {
            //use parent transform to make the direction right
            Vector3 _position = transform.parent.position;
            Vector2 direction = collider.transform.position - _position;//Player���VOrc���V�q

            attackPower = Random.Range(1, 10);
            bool isCritical = Random.Range(0, 100) < 30;
            if(isCritical)
            { 
                attackPower *= 2;
            }
            damageable.OnHit(attackPower, direction.normalized * knockbackForce);
            DamagePopup.Create(collider.transform.position, attackPower, isCritical);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
