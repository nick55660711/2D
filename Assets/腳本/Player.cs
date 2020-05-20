using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Range(0f,1f)] public float Speed;
    [Header("選擇操控的方式")]
    public Controltype control;
    public GameObject JoystickObject;
    bool UseJoystick;
    //判斷滑鼠是否點擊玩家物件
    public bool MouseClick;
    public enum Controltype
    {
        鍵盤,手機陀螺儀,滑鼠,手機搖桿
    }


    public float hp;
    public Image hp_bar;


    void Start()
    {
        
    }

    void Update()
    {
        #region 鍵盤控制說明
        /*  // Input.GetKey("a") 按住A鍵，if條件內的腳本會持續執行
        if (Input.GetKey("a"))
          {
              transform.position = new Vector3(transform.position.x - 0.02f, transform.position.y,transform.position.z);
          }
          // Input.GetKeyDown("d") 按住D鍵，if條件內的腳本只執行一次
          if (Input.GetKeyDown("d"))
          {
              transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y,transform.position.z);
          }

          // Input.GetKeyUp("s") 按下S鍵放開後，if條件內的腳本只執行一次
          if (Input.GetKeyUp("s"))
          {
          }
          */


        //Input.GetAxis("Horizontal") 沒有按按鍵的時候回傳值為0
        //Input.GetAxis("Horizontal") 按A或是左鍵的時候回傳值為-1
        //Input.GetAxis("Horizontal") 按D或是右鍵的時候回傳值為1
        //Input.GetAxis("Vertical") 沒有按按鍵的時候回傳值為0
        //Input.GetAxis("Vertical") 按S或是下鍵的時候回傳值為-1
        //Input.GetAxis("Vertical") 按W或是上鍵的時候回傳值為1
        #endregion
        #region
        // #if UNITY_STANDALONE  //PC上執行
        if ((int)control == 0) 
        transform.Translate(Speed * Input.GetAxis("Horizontal"), Speed * Input.GetAxis("Vertical"), 0f);


        //#endif

        //# if UNITY_ANDROID //Android上執行
        //  Input.acceleration.x 手機陀螺儀X軸 Input.acceleration.y 手機陀螺儀Y軸
        if ((int)control == 1)
            transform.Translate(Speed * Input.acceleration.x, Speed * Input.acceleration.y, 0f);

        // 滑鼠左鍵 ID=0 右鍵ID=1 滾輪按鍵ID=2
        /*
        if(Input.GetMouseButtonDown(0))
        if(Input.GetMouseButton(1))
        if(Input.GetMouseButtonUp(2))
        */
        if ((int)control == 2) 
        {
            if (Input.GetMouseButton(0))
            {
                if (MouseClick)
                {
                    // Input.mousePosition 抓取滑鼠座標
                    // Debug.Log(Input.mousePosition);

                    //宣告一個座標點
                    Vector3 mouse;
                    //Camera.main 透過遊戲主攝影機(Tag要是MainCamera)
                    // 鼠標在螢幕上的座標與編輯器的座標不同
                    //ScreenToWorldPoint 將螢幕的座標轉換成在遊戲編輯器內的座標

                    mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector3(mouse.x, mouse.y);
                    //隱藏鼠標
                    Cursor.visible = false;
                
                }
            }
                    else
                    {
                    //鼠標顯示
                    Cursor.visible = true;
                    }
        
        }

        if ((int)control == 3)
        {
            JoystickObject.SetActive(true);
        }
        else
        {
            JoystickObject.SetActive(false);
        }

        //#endif

        //限制數值Mathf.Clamp(限制的項目,最小值,最大值)

        transform.position=new Vector3(Mathf.Clamp(transform.position.x,-2.25f,2.25f), 
            Mathf.Clamp(transform.position.y, -4.6f, 4.6f),transform.position.z);
        #endregion
        hp = hp_bar.fillAmount;

        if (hp == 0) { Destroy(gameObject); }
    }

    //按下手機虛擬搖桿
    public void JoystickOn() { UseJoystick = true; }

    //放開手機虛擬搖桿
    public void JoystickOff() { UseJoystick = false; }
    // 按住手機虛擬搖桿
    public void JoystickUsing(Vector3  pos) 
    { 
        if(UseJoystick)
            transform.Translate(Speed * pos.x, Speed * pos.y, 0f);
    }
    /*
    //按下滑鼠左鍵在自機
    public void ClickOn()
    {
        MouseClick = true;
    }

    //放開滑鼠左鍵
    public void ClickOff()
    {
        MouseClick = false;
    }
    */
    private void OnMouseDown()
    {
        MouseClick = true;
    }
    private void OnMouseUp()
    {
        MouseClick = false;
    }










}
