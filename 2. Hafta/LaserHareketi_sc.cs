using UnityEngine;

public class LaserHareketi : MonoBehaviour
{

    public float hiz = 10f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * hiz * Time.deltaTime);
        
        if(transform.position.y > 12f)
        {
            Destroy(gameObject);
        }
    }
}
