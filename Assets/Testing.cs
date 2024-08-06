using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
    void OnFire()
    {
        Vector3 mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());//得到當前鼠標的位置
        mousePosition.z = 0;
        int attackPower = Random.Range(1, 10);
        bool isCritical = Random.Range(0, 100) < 30;
        DamagePopup.Create(mousePosition, attackPower, isCritical);
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
