using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadGun : MonoBehaviour
{

    public Transform weaponParent;


    // Start is called before the first frame update
    void Start()
    {
        int selectedGun = PlayerPrefs.GetInt("selectedGun");
        
        foreach(Transform weaponTransform in weaponParent)
        {
            weaponTransform.gameObject.SetActive(false);
        }
        weaponParent.GetChild(selectedGun).gameObject.SetActive(true);
    }

   
}
