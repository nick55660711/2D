using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [Range(0f, 1f)] public float Speed;


  
    void Update()
    {



        if (-0.1f <= transform.position.x - GameObject.Find("playerShip2_orange (1)").transform.position.x)
        {
            if (0.1f >= transform.position.x - GameObject.Find("playerShip2_orange (1)").transform.position.x)
            {

                transform.Translate(Speed * Input.GetAxis("Horizontal"), 0f, 0f);

            }
        }

        

        transform.Translate(0f, Speed * Input.GetAxis("Vertical"), 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10f, 10f),
                Mathf.Clamp(transform.position.y, 0, 0), transform.position.z);
    }
}
