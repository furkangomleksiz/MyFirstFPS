using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScript : MonoBehaviour
{

    public float damage = 100f;
    public float range = 500f;
    public float fireRate = 0.5f;


    public ParticleSystem muzzleFlash;
    public Camera fpsCam;

    private float nextTimeToFire = 0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
       
    }

    

    void Shoot()
    {

        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetScript target = hit.transform.GetComponent<TargetScript>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
