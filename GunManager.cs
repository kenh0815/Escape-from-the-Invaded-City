using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class GunManager : MonoBehaviour
{
    public LeapProvider leapProvider;

    [SerializeField] GameObject bulletPrefab;
    float power = 300;
    public int bulletNumber = 8;

    // Update is called once per frame
    void Update()
    {
        
        

        Frame frame = leapProvider.CurrentFrame;
        Hand _rightHand = frame.GetHand(Chirality.Right);
        Vector3 direction = Vector3.zero;

        if (_rightHand != null)
        {
            Vector3 palmPosition = _rightHand.PalmPosition;
            transform.position = new Vector3(palmPosition.x, palmPosition.y, palmPosition.z + 2);
        }
    }

    public void Shot()
    {
        if (bulletNumber != 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * power);
            GetComponent<AudioSource>().Play();
            bulletNumber--;
        }
        
    }


}
