using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // ��]���x (1�b�Ԃ�720�x = 2��])
    private float rotationSpeed = 180f;

    public GunManager gunManager;


    void Update()
    {
        // ��]�p�x���v�Z
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // �I�u�W�F�N�g����]������
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
