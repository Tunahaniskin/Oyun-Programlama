using UnityEngine;
using System;
using System.Collections;

public class Player_sc : MonoBehaviour
{

    public float playerHiz = 5.0f;

    float speedMultiplier = 2.0f;
    public GameObject LaserPrefab;
    public float SeriAtisSuresi = 0.3f;

    private float sonrakiAtisZamani = 0f;
     
     [SerializeField] //dışarıdan görünür yapar
    private int lives = 3;

    [SerializeField]   
    private GameObject tripleShoot;
    [SerializeField]
    private bool isTripleShootActive = false;
    
    [SerializeField]
    bool isSpeedBoostActive = false;

     [SerializeField]
    bool isShieldBonusActive = false;

    [SerializeField]
    GameObject shieldVisualizer;


    
    

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
        if (!isTripleShootActive)
        {
           Instantiate(LaserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
        else
        {
            Debug.Log(transform.position+ new Vector3(0f,0.8f,0));
        Instantiate(tripleShoot, transform.position+ new Vector3(0f,0.8f,0), Quaternion.identity);
        }

    }

    void CalculateMovement() // ekrandan çıkmaması için sınırlandırma
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalnput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalnput, 0);
        transform.Translate(direction * Time.deltaTime * playerHiz);

        transform.position = new Vector3(transform.position.x,
                                        Math.Clamp(transform.position.y, -2f, 2f),
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
        //koruma aktif ise can azalmıyor ama koruma pasif oluyor
        if (isShieldBonusActive)
        {
            isShieldBonusActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        //koruma yoksa can azalır
        lives--;
        if (lives < 1)
        {

            //burdan sonrası derste işledik destroy'a kadar
            Spawn_Manager_sc spawnManager_sc = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager_sc>();

            if (spawnManager_sc != null)
            {
                spawnManager_sc.OnPlayerDeath();
            }
            else
            {
                Debug.LogError("Player_sc::Damage spawnManager_sc is NULL");
            }

            Destroy(this.gameObject);
            
        }
    }
     public void TripleShootActive()
    {
         isTripleShootActive = true;
        StartCoroutine(TripleShotCancelRoutine());
    }

        IEnumerator TripleShotCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
         isTripleShootActive = false;
    }

    public void SpeedBoostActive()
    {
        isSpeedBoostActive = true;
        playerHiz *= speedMultiplier;
        StartCoroutine(SpeedBonusCancelRoutine());
    }
         IEnumerator SpeedBonusCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
         isSpeedBoostActive = false;
         playerHiz /= speedMultiplier;
    }

     public void ShieldBonusActive()
    {
         isShieldBonusActive = true;
         shieldVisualizer.SetActive(true);//unity den ilk başta pasif yapmıştık
    }

    

}
