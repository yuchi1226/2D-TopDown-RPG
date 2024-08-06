using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    Vector3 position;
    private int attackPower;//攻擊力
    public int knockbackForce;//彈開對方的力度

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
            //transform.localEulerAngles = new Vector3(0, 180, 0);  // Y軸旋轉180度
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        iDamageable damageable = collider.GetComponent<iDamageable>();

        if (damageable != null)
        {
            //use parent transform to make the direction right
            Vector3 _position = transform.parent.position;
            Vector2 direction = collider.transform.position - _position;//Player指向Orc的向量

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
