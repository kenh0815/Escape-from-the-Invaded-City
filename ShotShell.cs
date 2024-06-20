using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ShotShell : MonoBehaviour
{

    public Text shellLabel;
    public GunManager gunManager;


    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Gun");
        gunManager = obj.GetComponent<GunManager>();

        shellLabel.text = "íeêî : " + gunManager.bulletNumber;
    }

    private void Update()
    {
        shellLabel.text = "íeêî : " + gunManager.bulletNumber;
    }

}
