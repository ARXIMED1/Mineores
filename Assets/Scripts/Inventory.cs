using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventor;
    private bool isInventoryOpen = false;

    public GameObject gun;
    public GameObject furjace;
    public GameObject bulshit;

    private void Start()
    {
        inventor.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryOpen = !isInventoryOpen;
            inventor.SetActive(isInventoryOpen);
        }
    }
    public void Buton()
    {
        inventor.SetActive(false);
        isInventoryOpen = false;
    }
    public void Baton1()
    {
        furjace.SetActive(true);
        gun.SetActive(false);
        bulshit.SetActive(false);
    }
    public void Baton2()
    {
        furjace.SetActive(false);
        gun.SetActive(true);
        bulshit.SetActive(false);
    }
    public void Baton3()
    {
        furjace.SetActive(false);
        gun.SetActive(false);
        bulshit.SetActive(true);
    }
}