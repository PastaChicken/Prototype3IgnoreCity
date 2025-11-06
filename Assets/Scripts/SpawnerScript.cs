using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
   public GameObject BombPrefab;
   public float delayBeforeFirstSpawn = 2f;
   public float spawnInterval = .5f;
   public int numberOfSpawns = 100;

   void Start()
   {
      StartCoroutine(SpawnRoutine());
   }

   IEnumerator SpawnRoutine()
   {
      // Initial delay before the first spawn
      yield return new WaitForSeconds(delayBeforeFirstSpawn);

      for (int i = 0; i < numberOfSpawns; i++)
      {
         Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 260), 120, Random.Range(-20, 220));
         Instantiate(BombPrefab, randomSpawnPosition, Quaternion.identity);

         yield return new WaitForSeconds(spawnInterval);
      }
   }
}