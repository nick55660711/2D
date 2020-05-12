using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public VideoPlayer MovieOP;
    
    private void Start()
    {
        //依照時間持續呼叫function
        //InvokeRepeating(function名稱, 遊戲一開始要等待幾秒才呼叫第一次, 等待幾秒後呼叫第二次 , 第三次......);
        InvokeRepeating("CheckMovie", 3f, 0.1f);
    }


    private void Update()
    {


        // MovieOP.isPlaying = true 影片撥放中
        // MovieOP.isPlaying = false 影片非撥放
        // Timer的寫法
        //float Timer;
        /*
        Timer += Time.deltaTime;
        if(Timer > 3f)
        {
            if (MovieOP.isPlaying == false)
            {
                Application.LoadLevel("Game");
        }
        
            }*/
    }
    void CheckMovie() 
    {
        if (MovieOP.isPlaying == false)
        {
            Application.LoadLevel("Game");
        }
    
    }







}
