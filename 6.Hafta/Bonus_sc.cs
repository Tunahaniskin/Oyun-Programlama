using Unity.VisualScripting;
using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    [SerializeField]
    int bonusId;
    
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (this.transform.position.y < -5)
        {
           Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {// üçlü atış aktif 
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            if(player_sc != null)
            {
                switch (bonusId)
                {
                    case 0:
                        player_sc.TripleShootActive();
                        break;
                    case 1:
                       player_sc.SpeedBoostActive();
                        break;
                    case 2:
                        player_sc.ShieldBonusActive();
                        break;
                    //yalnızca 3 bonus var bunların dışıda hata vermesi için
                    default:
                        Debug.Log("Hatalı bonus idsi");
                        break;
                }
               
            }
            //bonus nesnesi yok edilmesi
            Destroy(this.gameObject);
        }
    }
}
