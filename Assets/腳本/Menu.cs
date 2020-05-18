using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public bool Controlsound = true;

    [Header("聲音按鈕圖片")]
    public Image SoundButtonImage;
    [Header("聲音開啟圖片")]
    public Sprite SoundOpenSprite;
    [Header("聲音關閉圖片")]
    public Sprite SoundCloseSprie;

    public Slider SoundSlider;

    public Dropdown ScreenSizeDropdwon;

    //Playerprefs 儲存/取值資料欄位的名稱
    string SaveAudioSlider = "SaveAudioSlider" ;
    string SaveRes = "SaveRes";


    private void Start()
    {
        //(全域變數寫法 SaveData腳本)SoundSlider.value = SaveData.SaveAudioSlider;
        SoundSlider.value = PlayerPrefs.GetFloat(SaveAudioSlider);
        ScreenSizeDropdwon.value = PlayerPrefs.GetInt(SaveRes);
        AudioListener.volume = SoundSlider.value;
        
    }
    private void Update()
    {
        AudioListener.volume = SoundSlider.value;

       

        
        //設定遊戲執行檔的解析度Screen.SetResolution(寬, 高, 是否全螢幕);
        
        /*if(ScreenSizeDropdwon.value == 0)
        {Screen.SetResolution(480, 800, false);}
        if(ScreenSizeDropdwon.value == 1)
        {Screen.SetResolution(720, 1280, false);} 
        if(ScreenSizeDropdwon.value == 2)
        {Screen.SetResolution(1080, 1920, false);}
        */

        switch (ScreenSizeDropdwon.value)
        {
            case 0:
                Screen.SetResolution(480, 800, false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(1080, 1920, false);
                break;
        }




    }







    #region 下一關
    public void NextScene()
    {
        //Application.LoadLevel("場景名稱"); 執行該場景
        //Application.LoadLevel(場景名稱ID); 執行該場景
        //Application.loadedLevel 讀取當前關卡名稱;
        //Application.LoadLevel(Application.loadedLevel); 重新遊戲
        //(全域變數寫法 SaveData腳本)SaveData.SaveAudioSlider = SoundSlider.value;
        //儲存浮點數 PlayerPrefs.SetFolat(儲存欄位名稱,儲存值);
        //儲存字串 PlayerPrefs.SetString(儲存欄位名稱,儲存值);
        //儲存整數 PlayerPrefs.SetInt(儲存欄位名稱,儲存值);
        PlayerPrefs.SetFloat(SaveAudioSlider, SoundSlider.value);
        PlayerPrefs.SetInt(SaveRes, ScreenSizeDropdwon.value);
        Application.LoadLevel("CH2. Level menu");


    }

    public void BackScene()
    {
        Application.LoadLevel("CH1. menu");
        Destroy(GameObject.Find("Hanekuriboh").gameObject);
    }

    #endregion

    #region 遊戲關閉
    public void Quit()
    {
        //Application.Quit();關閉程式
        //輸出成遊戲執行檔才可以進行測試

        Application.Quit();




    }

    #endregion

    #region 聲音控制
    public void Control_Sound()
    {
        Controlsound = !Controlsound;
        
        
        if (Controlsound == true)
         {
             //AudioListener.pause = false; 整體遊戲聲音播放
             AudioListener.pause = false;
            //聲音按鈕圖示轉成聲音開啟圖示
            SoundButtonImage.sprite = SoundOpenSprite;
        }

         else
         {
             //AudioListener.pause = true; 整體遊戲聲音暫停
             AudioListener.pause = true;
            //聲音按鈕圖示轉成聲音關閉圖示
            SoundButtonImage.sprite = SoundCloseSprie;

         }
         
    #endregion

        

    }

    public void ChangeAudioSlider()
    {
        if (SoundSlider.value == 0)
        {

            Controlsound = true ;
            Control_Sound();
        }
        else 
        {
            Controlsound = false; 
            Control_Sound();
                
        }





    }






}

