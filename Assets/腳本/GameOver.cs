using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    string SaveScore = "SaveScore";
    string SaveHighScore = "SaveHighScore";
    public Text ScoreText;
    public Text HighScoreText;
    string SaveClearScore = "SaveClearScore";
    public Text ClearScoreText;
    public int LevelID;
    string SaveLevelID = "SaveLevelID";
    public Button NextButton;

    //儲存每個關卡得分數





    private void Start()
    {
        LevelID = PlayerPrefs.GetInt(SaveLevelID);
        Cursor.visible = true;
        ScoreText.text = "Score :" + PlayerPrefs.GetFloat(SaveScore);
        HighScoreText.text ="Level " + LevelID + "\n" + "High Score :"  + PlayerPrefs.GetFloat(SaveHighScore + LevelID);
        ClearScoreText.text = "Clear Score :" + PlayerPrefs.GetFloat(SaveClearScore + LevelID);

        //如果當前分數<目標分數 = 失敗
        if (PlayerPrefs.GetFloat(SaveScore) < PlayerPrefs.GetFloat(SaveClearScore + LevelID)) 
        {
            NextButton.interactable = false;
        }
        //成功
        else
        {
            NextButton.interactable = true;

            if (PlayerPrefs.GetInt(SaveLevelID)  == Level.OpenLevelID)
            {
            Level.OpenLevelID++;
            }
        }

    
    }

    public void NextGame()
    {
        Application.LoadLevel("CH2. Level menu");
                
    }


}
