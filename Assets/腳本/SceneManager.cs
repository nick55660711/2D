using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
    
{
 
    [Header("移動到")]
    public string SceneName;

    public void NextScene() 
    {

        Application.LoadLevel(SceneName);
    }


   




}
