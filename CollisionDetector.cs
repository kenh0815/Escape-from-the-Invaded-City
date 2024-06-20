using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();
    


    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();

        }
    }

    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }
    
}
