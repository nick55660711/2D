using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("下一個關卡的名稱")]
    public string NextSceneName;
    public void NextScene()
    {
        Application.LoadLevel(NextSceneName);

       /* if (NextSceneName == "CH1. menu")
        {
            //Destroy刪除物件  
            //GameObject.Find("物件名稱") 尋找該物件
            //XXX(物件名稱).gameObject XXX物件本身  
            Destroy(GameObject.Find("Hanekuriboh").gameObject);
        }*/
        
        if(NextSceneName == "Movie")
        {
            //物件名稱.SetActive 判斷物件是否要開啟
            //GameObject.Find("Hanekuriboh").Setactive(false);
            //物件名稱.GetComponent<元件名稱>() 呼叫物件的元件
            //物件名稱.GetComponent<元件名稱>().enabled 判斷物件身上的元件是否開啟

            GameObject.Find("Hanekuriboh").GetComponent<AudioSource>().enabled = false;
        }

        if(NextSceneName == "Game")
        {
            GameObject.Find("Hanekuriboh").GetComponent<AudioSource>().enabled = true;
        }


    }
}
