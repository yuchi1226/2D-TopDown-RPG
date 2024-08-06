using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDamageable//class修改為interface表示他是一個接口
                            //與 Class 約定行為
                            //但 Interface 只描述有哪些 Method 和 Property 
                            //不包含怎麼執行。
{
    public void OnHit(int damage, Vector2 knockback);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
