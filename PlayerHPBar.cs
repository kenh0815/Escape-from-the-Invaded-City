using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 155;
    public int currentHp;
    public bool isZeroHP;
    public bool isAttacked = false;
    //Sliderを入れる
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
        //Debug.Log("Start currentHp : " + currentHp);
    }

    private void Update()
    { 
        slider.value = (float)currentHp / (float)maxHp; ;
        //Debug.Log("slider.value : " + slider.value);
        if (currentHp <= 0)
        {
            isZeroHP = true;
        }

    }

    /*
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            int damage = 1;
            

            
            currentHp = currentHp - damage;

            if(isAttacked)
            {
                currentHp = currentHp - 10;
                isAttacked = false;
            }
            
            
            
        }

    }
     */



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            GetComponent<AudioSource>().Play();
            currentHp = currentHp - 5;

            isAttacked = true;

        }
    }
}
