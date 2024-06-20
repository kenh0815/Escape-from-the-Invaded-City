using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class NewBehaviourScript : MonoBehaviour
{
    public LeapProvider leapProvider;

    public GunManager gunManager;

    private float jumpPower = 14f;
    private Rigidbody rb;
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = leapProvider.CurrentFrame;
        Hand _leftHand = frame.GetHand(Chirality.Left);
        Hand _rightHand = frame.GetHand(Chirality.Right);

        float speed = 20;
        Vector3 direction = Vector3.zero;

        if (_leftHand != null)
        {
            //Debug.Log("Left Hand Detected");


            //get the palm normal
            Vector3 palmNormal = _leftHand.PalmNormal;
            //Debug.Log("Palm Noral: " + palmNormal);
            direction = new Vector3(-palmNormal.x * 0.02f, 0f, -palmNormal.z * 0.02f);

            Vector3 palmPosition = _leftHand.PalmPosition;
            //Debug.Log("Palm Position: " + palmPosition);
            //speed = palmPosition.y;
            if (palmPosition.y > 10 && !isJump)
            {
                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
                isJump = true;
            }

        }

        if (_rightHand != null)
        {
            //Debug.Log("Right Hand Detected");
        }
        transform.Translate(direction * speed);
        
        

    }

    //ínñ Ç…íÖínÇµÇΩÇÁisJumpÇfalse
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Goal")){
            Debug.Log("ÉSÅ[Éã");
        }
        
    }

}
