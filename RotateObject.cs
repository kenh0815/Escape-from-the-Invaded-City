using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // ‰ñ“]‘¬“x (1•bŠÔ‚É720“x = 2‰ñ“])
    private float rotationSpeed = 180f;

    public GunManager gunManager;


    void Update()
    {
        // ‰ñ“]Šp“x‚ðŒvŽZ
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // ƒIƒuƒWƒFƒNƒg‚ð‰ñ“]‚³‚¹‚é
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
