using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class ObjectPoolController : MonoBehaviour
{

    protected List<GameObject> ObjectPool = new List<GameObject>();

    public void AddToPool(GameObject Object)
    {
        ObjectPool.Add(Object);
    }

    protected void MakeObjects(GameObject ObjectPrefab, int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject temp = Instantiate(ObjectPrefab, new Vector3(10, 10, 0), Quaternion.identity);
            ObjectPool.Add(temp);
            ObjectPool[i].SetActive(false);
        }
    }


    protected GameObject RandomSpawnObject(Vector3 position)
    {
        if (ObjectPool.Count > 0)
        {
            float y =  Random.RandomRange(-5, 5) +position.y;
            float x = Random.RandomRange(-7, 7) + position.x ; 
            GameObject bady = ObjectPool[0];
            bady.SetActive(true);
            ObjectPool.RemoveAt(0);
            
            bady.GetComponent<Transform>().position = new Vector3(x, y, 0);
            return bady;
        } else
        {
            return null;
        }
    }

    protected GameObject SpawnObject(Vector3 position)
    {
        if (ObjectPool.Count > 0)
        {
            GameObject bady = ObjectPool[0];
            bady.SetActive(true);
            ObjectPool.RemoveAt(0);

            bady.GetComponent<Transform>().position = new Vector3(position.x, position.y, 0);
            return bady;
        }
        else
        {
            return null;
        }
    }
}
