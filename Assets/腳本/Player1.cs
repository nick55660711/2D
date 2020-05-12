using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    
   
    [Range(0f, 1f)] public float Speed1;



    void Update()
    {





        transform.Translate(Speed1 * Input.GetAxis("Horizontal"), 0f, 0f);
        transform.Translate(0f, Speed1 * Input.GetAxis("Vertical"), 0f);



        transform.position = new Vector3(Mathf.Clamp(transform.position.x,
            GameObject.Find("Main Camera").transform.position.x - 2.25f,
            GameObject.Find("Main Camera").transform.position.x + 2.25f),
            Mathf.Clamp(transform.position.y, -4.6f, 4.6f), transform.position.z);


    }
}
