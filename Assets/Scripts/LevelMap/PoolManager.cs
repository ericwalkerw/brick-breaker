using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Queue<GameObject> objectPool = new Queue<GameObject>();
    public void SpawnObjects()
    {
        while (true)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject spawnedObj = GetObjectFromPool(spawnPosition, spawnRotation);
            if (spawnedObj != null)
            {
                Debug.Log("Spawned object from pool.");
                StartCoroutine(ReturnObjectAfterDelay(spawnedObj));
            }
        }
    }

    private GameObject GetObjectFromPool(Vector3 position, Quaternion rotation)
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }

        return null;
    }

    public IEnumerator ReturnObjectAfterDelay(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        ReturnObjectToPool(obj);
    }

    private void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
