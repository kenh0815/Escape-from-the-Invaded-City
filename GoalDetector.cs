using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    public bool isGoal = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�S�[��");
            GetComponent<AudioSource>().Play();
            isGoal = true;
        }
    }

}
