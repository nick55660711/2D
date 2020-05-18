using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [Header("設定幾秒產生一枚子彈")]
    public float CreateTime;
    [Header("子彈")]
    public GameObject Bullet;
    [Header("子彈生成點")]
    public Transform CreateObject;
    [Header("射擊音效")]
    public AudioSource ShootingSound;
    
    void Start()
    {
        ShootingSound = GameObject.Find("shoot10").GetComponent<AudioSource>();
        InvokeRepeating("CreateBullet", CreateTime, CreateTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void CreateBullet() {

        //動態生成 Instantiate(要生成的物件, 生成出來以後的物件位置, 生成出來以後的物件角度);
        Instantiate(Bullet,CreateObject.position,CreateObject.rotation);
        ShootingSound.Play();
    }



}
