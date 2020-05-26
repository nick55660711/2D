using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [Header("下一個關卡的名稱")]
    public string NextSceneName;
    public Text LevelText;
    [Header("關卡通過分數")]

    //儲存每個關卡得分數

    string SaveClearScore = "SaveClearScore";
    public float SetClearScore;
    string SaveHighScore = "SaveHighScore";
    public float SetHighScore ;
    string SaveLevelID = "SaveLevelID";
    public int LevelID;

    // int memevalue;
    //紀錄開啟的關卡數量
    static public int OpenLevelID ;
    //抓取所有Level頁面所有關卡按鈕
    //public GameObject[] LevelButton;


    private void Start() 
    {

        if (Application.loadedLevelName == "CH2. Level menu" && tag == "LevelButton")
        {
                //抓取子物件
                LevelText = GetComponentInChildren<Text>();

                //將字串轉為整數值
                LevelID = int.Parse(LevelText.text);
        }

        SetHighScore = PlayerPrefs.GetFloat(SaveHighScore + LevelID);
        // LevelButton = GameObject.FindGameObjectsWithTag("LevelButton");

        //自動抓取tag為LevelButton的按鈕放入陣列中
        //用for迴圈開啟按鈕

        /*
        for (int i = 0; i<= OpenLevelID; i++)
        {
            LevelButton[i].GetComponent<Button>().interactable = true;
        }
        */

        if (OpenLevelID >= LevelID) 
        {
            GetComponent<Button>().interactable = true;
        }

        else
        {
            GetComponent<Button>().interactable = false;

        }

    }












    public void NextScene()
    {
        //跳關卡到Game畫面前，先將每關最高分數儲存
        PlayerPrefs.SetInt(SaveLevelID, LevelID);
        //PlayerPrefs.SetFloat(SaveHighScore + LevelID, SetHighScore);
        PlayerPrefs.SetFloat(SaveClearScore + LevelID, SetClearScore);

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




            //物件名稱.SetActive(bool) 判斷物件是否要開啟
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
