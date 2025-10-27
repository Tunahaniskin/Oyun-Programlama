using UnityEngine;
using System;

public class Player_sc : MonoBehaviour
{

    public float playerHiz = 5.0f;
    public GameObject LaserPrefab;
    public float SeriAtisSuresi = 0.3f;

    private float sonrakiAtisZamani = 0f;
     
     [SerializeField] //dışarıdan görünür yapar
    private int lives = 3;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {   
        CalculateMovement();
        if (Input.GetKey(KeyCode.Space) && Time.time >=sonrakiAtisZamani)
        {
            sonrakiAtisZamani = Time.time + SeriAtisSuresi;
            AtisYap(); 
        }
    }

    void AtisYap()
    {

        Instantiate(LaserPrefab, transform.position, transform.rotation);

    }

    void CalculateMovement() // ekrandan çıkmaması için sınırlandırma
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalnput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalnput, 0);
        transform.Translate(direction * Time.deltaTime * playerHiz);

        transform.position = new Vector3(transform.position.x,
                                        Math.Clamp(transform.position.y, 0, 2f),
                                         0);

        if (this.transform.position.x > 9.26)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (this.transform.position.x < -9.5)
        {
            transform.position = new Vector3(9.26f, transform.position.y, 0);
        }
    }
    

    public void Damage()
    {
        lives--;
        if (lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
