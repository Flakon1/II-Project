using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZonesManager : MonoBehaviour {

    /* Attributes */

    [SerializeField] private GameObject zonesManager; // Attribute for zones manager
    [SerializeField] private GameObject zonesContent; // Attribute for zones panel content
    [SerializeField] private GameObject zonePrefab; // Attribute that represents the standard form of a zone
    private List<GameObject> zones = new List<GameObject>(); // Attribute for zones list
    private static int currentPressedZone; // Attribute for identifying the current pressed zone

    /* Main Methods */
    
    private void Awake() {
        LoadZonesFromDatabase(); // Loading zones from data base *needs to be implemented*
    }

    /* Custom Methods */

    private void LoadZonesFromDatabase() { // Loading zones from data base *needs to be implemented*
        // For each zone in database, add a new object inside zone list
        if(zones == null || SceneManager.GetActiveScene().name != "StartingPage") {
            return;
        }
        for(int i = 0; i < 10; i++) { // Example of implementation
            GameObject newZone = Instantiate(zonePrefab, zonesContent.transform);
            newZone.name = "Zone_" + i; // Take the name from the database
            newZone.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newZone.name;
            int index = i;
            newZone.GetComponent<Button>().onClick.AddListener(() => SelectZones(index)); // Adding the correspondent index
            zones.Add(newZone);
        }
    }
    private void SelectZones(int index) { // Open selected zones panel
        currentPressedZone = index;
        Debug.Log("Pressed Zone_" + index);
        ButtonsManager.ReturnToPage("BeachPage");
    }

    /* Getters */

    public static int GetCurrentPressedZone() { // Getter for the current zone pressed
        return currentPressedZone;
    }
    public List<GameObject> GetZones() { // Getter for zones list
        return zones;
    }
}