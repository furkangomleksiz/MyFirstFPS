using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponADS : MonoBehaviour
{

    public int sw;
    public WeaponSwitch weaponSwitch;

    public Animator animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    private bool isSniperScoped = false;
    private bool isAkADS = false;
    private bool isPistolADS = false;
    public float scopedFOV = 15f;
    public float normalFOV;




    // Update is called once per frame
    void Start()
    {
     
        GameObject WeaponHolder = GameObject.Find("WeaponHolder");
        weaponSwitch = WeaponHolder.GetComponent<WeaponSwitch>();               
    }

    void Update()
    {
        sw = weaponSwitch.selectedWeapon;

        if (Input.GetButtonDown("Fire2") && sw == 0)
        {
            isPistolADS = !isPistolADS;
            animator.SetBool("PistolAimDown", isPistolADS);
        }

        if (Input.GetButtonDown("Fire2") && sw == 1)
        {
            isAkADS = !isAkADS;
            animator.SetBool("AkAimDown", isAkADS);
        }

        if (Input.GetButtonDown("Fire2") && sw == 2)
        {
            isSniperScoped = !isSniperScoped;
            animator.SetBool("SniperScoped", isSniperScoped);

            if (isSniperScoped)
                StartCoroutine(OnSniperScoped());
            else
                OnUnSniperScoped();
        }
    }

    IEnumerator OnSniperScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void OnUnSniperScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        
        mainCamera.fieldOfView = normalFOV;
    }
}
