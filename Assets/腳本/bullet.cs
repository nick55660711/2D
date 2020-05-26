using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    [Header("子彈速度")]
    public float speed;
    [Header("子彈存在時間")]
    public float DeleteTime;
    public GameObject Effect;
    public AudioSource EffectAudio;
    public float atk;



    private void Start()
    {
        EffectAudio = GameObject.Find("bom1").GetComponent<AudioSource>();

        Destroy(gameObject, DeleteTime);
    }

    void Update()
    {
        //Vector3.up=(0,1,0)  Vector3.down=(0,-1,0) Vector3.forward=(1,0,0)
        //transform.Translate(0,speed,0)
        transform.Translate(Vector3.up * speed);

        if (transform.position.y > Camera.main.transform.position.y + 5 ) { Destroy(gameObject); }


       
    }
    //穿透型觸碰方式 OnTriggerEnter , OnTriggerStay , OnTriggerExit
    //不穿透型碰撞 OnCollisionEnter , OnCollisionStay , OnCollisionExit
    //Enter 兩個物件一接觸 Function內的程式執行一次
    //Stay 兩個物件接觸 Function內的程式持續執行
    //Exit 兩個物件接觸後分離 Function內的程式執行一次
    //OnTriggerEnter 3維座標 OnTriggerEnter2D 二維座標
    void OnTriggerEnter2D(Collider2D other) {
        //玩家的子彈打到有collider2D物件時，檢測該物件的標籤是否為Enemy
        if (other.tag == "Enemy"&&gameObject.tag=="PlayerBullet") {
            //動態生成爆炸特效
                //other.transform.position 兩個物件接觸的位置
                //other.transform.rotation 兩個物件接觸的旋轉值
            Instantiate(Effect, other.transform.position, other.transform.rotation);
            //爆炸音效
            EffectAudio.Play();
            //敵機消滅
            Destroy(other.gameObject);

            //玩家子彈打中敵機，玩家加分
            GameObject.Find("player").GetComponent<Player>().GetScore(100);
            //子彈物件消滅
            Destroy(gameObject);
        }





        if (other.tag == "PlayerBullet" && gameObject.tag == "EnemyBullet")
        {
            //動態生成爆炸特效
           
            Instantiate(Effect, other.transform.position, other.transform.rotation);

            //爆炸音效
            EffectAudio.Play();

            //子彈物件消滅
            Destroy(gameObject);

            Destroy(other.gameObject);
        }

     
        
        
        
        if (other.tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            //動態生成爆炸特效
           
            Instantiate(Effect, other.transform.position, other.transform.rotation);

            //爆炸音效
            EffectAudio.Play();


            other.GetComponent<Player>().HurtPlayer(atk);
            //子彈物件消滅
            Destroy(gameObject);
        }
        
    }

}
