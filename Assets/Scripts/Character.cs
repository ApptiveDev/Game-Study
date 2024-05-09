using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Character : MonoBehaviour
{    
    private float CharacterHealthPoint = 10f;
    public float Speed = 1;
    public int Exp = 0;
    public int Level = 0;
    [SerializeField] private Image hpBarImage;
    [SerializeField] private Image expBarImage;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject expCoin;
    private float expPercent;
    RotatingWeapon RW;
    private Animator animator;
    

    void Start() {
        animator = GetComponent<Animator>();
        Instantiate(heart,new Vector3(-30.85f,15.97f,0),Quaternion.identity);
        Instantiate(expCoin,new Vector3(-30.85f,13.82f,0),Quaternion.identity);
        hpBarImage.transform.position = new Vector3(298,1012,0);
        expBarImage.transform.position = new Vector3(298,939,0);
    }

    void Update()
    {
        Walk();
        RunAndflip();
        HpBar();
        ExpBar();
    }

    void Walk() {
        animator.SetInteger("AnimState",0);
    }

    void RunAndflip() 
    {
        Vector2 vec = new Vector2(0f,0f);

        if (Input.GetKey (KeyCode.A)) {
            animator.SetInteger("AnimState",2);
            transform.localScale = new Vector3(3.3849f,3.3849f,3.3849f);
            vec.x = -1f;
        }

        if (Input.GetKey (KeyCode.D)) {
            animator.SetInteger("AnimState",2);
            transform.localScale = new Vector3(-3.3849f,3.3849f,3.3849f);
            vec.x = 1f;
        }

        if (Input.GetKey (KeyCode.W)) {
            animator.SetInteger("AnimState",2);
            vec.y = 1f;
        }

        if (Input.GetKey (KeyCode.S)) {
            animator.SetInteger("AnimState",2);
            vec.y = -1f;
        }

        transform.Translate(vec.normalized * Time.deltaTime * 8f * Speed);

        if (transform.position.x < -31.5f) {
            transform.position = new Vector3(-31.5f,transform.position.y,0);
        }

        if (transform.position.x > 31.5f) {
            transform.position = new Vector3(31.5f,transform.position.y,0);
        }

        if (transform.position.y < -18) {
            transform.position = new Vector3(transform.position.x,-18,0);
        }

        if (transform.position.y > 14) {
            transform.position = new Vector3(transform.position.x,14,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {   
            CharacterHealthPoint--;
            if (CharacterHealthPoint < 1) {
                CharaterDead();
            }
        }
    }

    public void CheckLevelUp() {
        if (Exp == ((Level+1) * 5))
        {
            Level++;
            RW = GameObject.Find("RotatingWeapon").GetComponent<RotatingWeapon>();
            if (RW.Level < 4) {
                Time.timeScale = 0f;
                GameObject.FindGameObjectWithTag("Image1").transform.position = new Vector3(508.98f,540,0);
                GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(960,540,0);
            }
            else {
                GameObject.FindGameObjectWithTag("Image2").transform.position = new Vector3(960,540,0);
            }
            Exp = 0;
        }
    }

    private void CharaterDead()
    {
        HpBar();
        gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void HpBar() {
        float hpPercent = CharacterHealthPoint / 10f;
        hpBarImage.fillAmount = hpPercent;
    }

    private void ExpBar() {
        expPercent = (float)Exp / (float)((Level+1)*5);
        expBarImage.fillAmount = expPercent;
    }
}
