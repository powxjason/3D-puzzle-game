using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCellInteraction : MonoBehaviour
{
    public bool HoldingPowerCell = false;
    public int PowerCellCount = 0;

    public GameObject PowerCellPrefab;
    public GameObject PowerCellIcon1;
    public GameObject PowerCellIcon2;
    public GameObject PowerCellIcon3;

    public void Start()
    {
        UpdateUI();
    }

    public void GrabPowerCell(GameObject CellFloor)
    {
        // Adds a Power Cell to your inventory and destroys the one on the floor
        Destroy(CellFloor);
        PowerCellCount += 1;
        UpdateUI();
    }

    public void PlacePowerCell(GameObject CellPlace)
    {
        // Removes a Power Cell from your inventory and places it in a slot    
        if (PowerCellCount > 0)
        {
            CellPlace.SetActive(true);
            PowerCellCount -= 1;
            UpdateUI();
        }
    }

    public void PullPowerCell(GameObject CellPlace)
    {
        // Adds a Power Cell to your inventory and takes it out of a slot        
        CellPlace.SetActive(false);
        UpdateUI();
    }

    public void UpdateUI()
    {
        switch (PowerCellCount)
        {
            case 3:
                HoldingPowerCell = true;
                PowerCellIcon1.SetActive(true);
                PowerCellIcon2.SetActive(true);
                PowerCellIcon3.SetActive(true);
                break;
            case 2:
                HoldingPowerCell = true;
                PowerCellIcon1.SetActive(true);
                PowerCellIcon2.SetActive(true);
                PowerCellIcon3.SetActive(false);
                break;
            case 1:
                HoldingPowerCell = true;
                PowerCellIcon1.SetActive(true);
                PowerCellIcon2.SetActive(false);
                PowerCellIcon3.SetActive(false);
                break;
            case 0:
                HoldingPowerCell = false;
                PowerCellIcon1.SetActive(false);
                PowerCellIcon2.SetActive(false);
                PowerCellIcon3.SetActive(false);
                break;
        }
    }
}
