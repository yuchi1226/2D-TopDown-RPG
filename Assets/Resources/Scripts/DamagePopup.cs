using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Vector3 moveVector;
    public float disappearTimer;
    public float disappearSpeed;
    private Color textColor;
    private const float DISAPPEAR_TIMER_MAX = 1f;

    private static int sortingOrder;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textColor = textMesh.color;
    }
    public static DamagePopup Create(Vector3 position, int damageAmount, bool isCriticalHit)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.DamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCriticalHit);
        return damagePopup;
    }
    private void Setup(int damageAmount, bool isCriticalHit)
    {
        textMesh.SetText(damageAmount.ToString());
        if (!isCriticalHit)
        {
            textMesh.fontSize = 5;
        }
        else
        {
            textMesh.fontSize = 7;
            textColor = Color.red;
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(0.7f, 1)*10;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 7 * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * 0.5f)
        {
            //First half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            //Second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale += Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            //Start to dissapear
            textColor.a -= disappearSpeed * Time.deltaTime;//³z©ú«×­°¬°0
            textMesh.color = textColor;
            if (textColor.a < 0)
            { 
                Destroy(gameObject); 
            }
                
        }
            
    }
}
