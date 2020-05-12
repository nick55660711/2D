using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryOnload : MonoBehaviour
{

    //DontDestroyOnLoad(object) 切換場景時不要把物件object刪除
    //gameObject代表物件自己

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    
    }





     

}
