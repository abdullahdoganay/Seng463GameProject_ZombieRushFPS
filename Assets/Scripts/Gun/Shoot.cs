using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float cooldawn = 0.05f;
    float lastFireTime = 0;
    public int defaultAmmo = 999999999;
    public int magSize = 30;
    public int currentAmmo;
    public int currentMagAmmo;
    public Camera Camera;
    public int range;
    [Header("Gun Damage On Hit")]
    public int damage;
    public GameObject bloodPrefab;
    public GameObject decalPrefab;
    public GameObject magObject;
    //public ParticleSystem muzzleParticle;
    int minAngle = -1;
    int maxAngle = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = defaultAmmo - magSize;
        currentMagAmmo = magSize;
        //Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (Input.GetMouseButton(0))
        {
            if (CanFire())
            {
                Fire();
            }
            
        }
    }

    private void Reload()
    {
        if (currentAmmo == 0 || currentMagAmmo == magSize)
        {
            return;
        }

        if (currentAmmo < magSize)
        {
            currentMagAmmo = currentMagAmmo + currentAmmo;
            currentAmmo = 0;
            

        }
        else
        {
            currentAmmo -= magSize - currentMagAmmo;
            currentMagAmmo = magSize;
        }
        GameObject newMagObject = Instantiate(magObject);
        newMagObject.transform.position = magObject.transform.position;
        newMagObject.AddComponent<Rigidbody>();
        
    }

    private bool CanFire()
    {
       
        if (currentMagAmmo > 0 && lastFireTime + cooldawn < Time.time)
        {
            lastFireTime = Time.time + cooldawn;
            return true;
        }
        return false;
        
    }

    private void Fire()
    {
        //muzzleParticle.Emit(15);
        currentMagAmmo = currentMagAmmo -1;
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, 1000))
        {
            if(hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<ZombieHealth>().Hit(damage);
                GenerateBloodEffect(hit);      

            }
            else
            {
                GenerateHitEffect(hit);
            }
        }
        transform.localEulerAngles = new Vector3(UnityEngine.Random.Range(minAngle,maxAngle), UnityEngine.Random.Range(minAngle, maxAngle), UnityEngine.Random.Range(minAngle, maxAngle));
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab,hit.point,hit.transform.rotation);
      

    }

    private void GenerateHitEffect(RaycastHit hit)
    {
        GameObject hitObject = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward * -1,hit.normal);
    }
}
