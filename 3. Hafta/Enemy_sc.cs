using UnityEngine;

public class Enemy_sc : MonoBehaviour
{

    public int  speed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        if(this.transform.position.y < -5.5f)
        {
           this.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Player'ın canını 1 azalt
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            player_sc.Damage();

            Destroy(this.gameObject);
            
        }
       
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
