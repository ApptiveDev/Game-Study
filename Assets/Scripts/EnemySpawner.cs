using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 3f;
    [SerializeField] int spawnAmount = 2;

    [SerializeField] GameObject enemyObject;

    public List<Enemy> enemyList = new List<Enemy>();

    public static EnemySpawner instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //���ʿ� �ѹ��� ������ ��ġ�� ������Ű�� �ʹ�

    private void Start()
    {
        StartCoroutine(SpawnbyTime());
    }


    float currentDelay = 0f;
    void Update()
    {
        //if (currentDelay < spawnDelay)
        //{
        //    currentDelay += Time.deltaTime;
        //}
        //else
        //{
        //    for(int i = 0; i < spawnAmount; i++)
        //    {
        //        currentDelay = 0f;
        //        SpawnObject();
        //    }
        //}
    }

    IEnumerator SpawnbyTime() // �ڷ�ƾ
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0; i < spawnAmount; i++)
            {
                enemyList.Add(SpawnEnemy());
            }
        }
    }

    public void RemoveEnemyOnList(Enemy enemy)
    {
        enemyList.Remove(enemy);
    }

    public Enemy SpawnEnemy()
    {
        //����
        return Instantiate(enemyObject, GetRndPos(), Quaternion.identity).GetComponent<Enemy>();
    }
    
    Vector3 GetRndPos()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);
        Vector3 rndPos = new Vector3(x, y, 0);
        return rndPos;
    }
}
