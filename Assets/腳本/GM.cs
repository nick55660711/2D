using UnityEngine;

public class GM : MonoBehaviour
{

    [Header("所有敵機物件")]
        public GameObject[] Enemy;
    [Header("敵機產生時間")]
        public float CreateTime;
    void Start()
    {
        InvokeRepeating("CreateEnemy", CreateTime, CreateTime);
    }

    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(-2.3f, 2.3f), transform.position.y, transform.position.z);
        //動態生成 Instantiate(要生成的物件, 生成出來以後的物件位置, 生成出來以後的物件角度);
        Instantiate(Enemy[Random.Range(0,Enemy.Length)],pos,transform.rotation);
        
    }


}
