using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject FireShot;
    public GameObject BigShot;
    // Update is called once per frame
    void Update()
    {
        //Left click Fires main weapon
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject circle;
            circle = Instantiate(FireShot, transform);

            circle.GetComponent<Rigidbody>().AddForce(Vector3.up * 400f, ForceMode.Impulse);
        }
        //Right click fires alt weapon
        if(Input.GetButtonDown("Fire2"))
        {
            GameObject capsule;
            capsule = Instantiate(BigShot, transform);

            capsule.GetComponent<Rigidbody>().AddForce(Vector3.up * 400f, ForceMode.Impulse);
        }
    }
}
