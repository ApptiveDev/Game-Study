using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataController : MonoBehaviour
{

    [SerializeField] private GameDataContainer gameDataContainer;
    [SerializeField] private WeaponDataContainer weaponDataContainer;
    [SerializeField] private EnemyDataContainer enemyDataContainer;

    private static GameDataController instance = null;

    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private int coin;
   

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        InitData();
    }

    private void InitData()
    {
        hp = 10;
        coin = 0;
        speed = 5;
    }

    public WeaponDataContainer GetWeaponData()
    {
        return weaponDataContainer;
    }

    public static GameDataController Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetCoin()
    {
        return coin;
    }

    public void SetCoin(int coin)
    {
        this.coin = coin;
    }

}
