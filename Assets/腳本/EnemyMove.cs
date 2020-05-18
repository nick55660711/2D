
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float deletetime;
    public float speed;

    void Start()
    {
        Destroy(gameObject, deletetime);    
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed);
    }
}
