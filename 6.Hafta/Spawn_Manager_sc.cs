using System.Collections;
using UnityEngine;

public class Spawn_Manager_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //private yazmadan direkt yaparsan private olur default

    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    GameObject[] bonusPrefabs;//spawn manager nesnenin içersinden atama yapmamız lazım dizinin boyutunu verip bonusId lere göre atama yapacağız
    
    [SerializeField]
    bool stopSpawning = false;
    
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }


    IEnumerator SpawnRoutine()
    {
        while (stopSpawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);

            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);

            enemy.transform.parent = enemyContainer.transform;

            yield return new WaitForSeconds(5.0f);

        }
    }
    
    public void OnPlayerDeath()
    {
        stopSpawning = true;
        
    }

    IEnumerator SpawnBonusRoutine()
    {
        while (stopSpawning == false)
        {
            int waitTİme = Random.Range(5, 10);
            Debug.Log("Bonus spawn için bekleme süresi: " + waitTİme);
            yield return new WaitForSeconds(waitTİme);

            Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);

            int randomBonus = Random.Range(0, 3); //0 ve 1 ve 2 dahil 3 hariç
            GameObject tripleShoot = Instantiate(bonusPrefabs[randomBonus], position, Quaternion.identity);

        }
    }

}
