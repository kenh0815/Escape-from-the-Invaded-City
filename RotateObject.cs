using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // 回転速度 (1秒間に720度 = 2回転)
    private float rotationSpeed = 180f;

    public GunManager gunManager;


    void Update()
    {
        // 回転角度を計算
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // オブジェクトを回転させる
        transform.Rotate(Vector3.up, rotationAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject obj = GameObject.Find("Gun");
            gunManager = obj.GetComponent<GunManager>();
            gunManager.bulletNumber += 8;
            Destroy(this.gameObject);
        }
    }
}
