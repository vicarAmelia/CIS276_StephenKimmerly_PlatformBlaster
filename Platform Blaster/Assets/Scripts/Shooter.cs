using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireShot;
    

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Fire1"))
      {
          Shoot();
      }  
    }

    void Shoot()
    {
        Instantiate(fireShot, firePoint.position, firePoint.rotation);
    }
}
