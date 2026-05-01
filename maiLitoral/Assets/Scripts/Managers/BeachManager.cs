
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeachManager : MonoBehaviour {

    /* Attributes */

    [SerializeField] private TextMeshProUGUI propertiesText; // Attribute for properties text
    [SerializeField] private GameObject beachesContent; // Attribute for beaches panel content
    [SerializeField] private GameObject propertiesContent; // Attribute for properties panel content
    [SerializeField] private GameObject beachCalendar; // Attribute for calendar object
    [SerializeField] private GameObject beachPrefab; // Attribute that represents the standard form of a beach
    [SerializeField] private GameObject propertyPrefab; // Attribute that represents the standard form of a property
    [SerializeField] private GameObject reviewCalendarPrefab; // Attribute that represents the standard form of review and calendar preset
    [SerializeField] private List<GameObject> scrollViews; // Attribute for beach manager scroll views
    private List<GameObject> beaches = new List<GameObject>(); // Attribute for beaches list
    private List<(string name, float rank)> top3Ranks = new List<(string name, float rank)>() { // Attribute for top 3 beaches *delete values after database implementation*
        ("Mamaia", 0.4f),
        ("Mangalia", 2.6f),
        ("Vama Veche", 3.5f),
    };
    private Color[] statusColors = new Color[] { // Attribute for 5 colors (each for status 0->4)
        Color.red,
        new Color(1f, 0.5f, 0f),
        Color.yellow,
        new Color(0.5f, 1f, 0f),
        Color.green,
    };
    private static int currentPressedZone; // Attribute for identifying the current pressed zone
    private static int currentPressedBeach; // Attribute for identifying the current pressed beach
    private bool reviewMode = false; // Attribute for review mode

    /* Main Methods */

    private void Start() {
        LoadBeachesFromDatabase(); // Loading zones from data base *needs to be implemented*
    }

    /* Custom Methods */

    private void LoadBeachesFromDatabase() { // Loading zones from data base *needs to be implemented*
        currentPressedZone = ZonesManager.GetCurrentPressedZone();
        // For each beach in database, add a new object inside beach list
        if(beaches == null || SceneManager.GetActiveScene().name == "StartingPage") {
            for(int i = 0; i < 3; i++) {
                GameObject topBeaches = GameObject.Find("TopBeaches"); // Finding in scene the needed object by it's name
                topBeaches.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = top3Ranks[i].name;
                topBeaches.transform.GetChild(i).transform.GetChild(1).GetComponent<Image>().color = statusColors[Mathf.FloorToInt(top3Ranks[i].rank + 0.5f)]; // Adding status color
                // topBeaches.transform.GetChild(i).transform.GetChild(2).GetComponent<Image>().sprite = something; // Need to add image from database (most probably)
            }
            return;
        }
        for(int i = 0; i < currentPressedZone * UnityEngine.Random.Range(1, 5) + 1; i++) { // Example of implementation
            GameObject newBeach = Instantiate(beachPrefab, beachesContent.transform);

            newBeach.name = "Beach_" + i; // Take the name from the database *needs database implementation*
            newBeach.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newBeach.name;

            newBeach.AddComponent<Beach>();
            Beach currentBeachScript = newBeach.GetComponent<Beach>();

            currentBeachScript.AddRank(UnityEngine.Random.Range(1f, 8f) / 2); // Example of adding rank *needs database implementation*

            for(int j = 0; j < 5 * UnityEngine.Random.Range(4, 8); j++) { // Example of adding properties *needs database implementation*
                currentBeachScript.AddProperty("Property_" + j, UnityEngine.Random.Range(1, 25) % 2 == 0);
            }

            int index = i;
            newBeach.GetComponent<Button>().onClick.AddListener(() => SelectBeach(index)); // Adding the correspondent index
            newBeach.transform.GetChild(1).GetComponent<Image>().color = statusColors[Mathf.FloorToInt(currentBeachScript.GetRank() + 0.5f)]; // Adding status color
            // newBeach.transform.GetChild(2).GetComponent<Image>().sprite = something; // Need to add image from database (most probably)
            beaches.Add(newBeach);
        }
    }
    private void LoadBeachProperties(int index) { // Loading properties for each beach
        if (beaches == null || SceneManager.GetActiveScene().name != "BeachPage") {
            return;
        }
        if(propertiesContent.transform.childCount != 0) { // Destroying already shown properties
            foreach(Transform property in propertiesContent.transform) {
                Destroy(property.gameObject);
            }
        }

        List<(string description, bool status)> beachProperties = beaches[index].GetComponent<Beach>().GetBeachProperties();
        List<bool> propertiesModified = beaches[index].GetComponent<Beach>().GetPropertiesModified();

        for(int i = 0; i < beachProperties.Count; i++) {
            int newIndex = i;
            GameObject newProperty = Instantiate(propertyPrefab, propertiesContent.transform);
            string propertyName = beachProperties[i].description;
            newProperty.name = propertyName;
            newProperty.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = propertyName;
            if(reviewMode == true) { // If user is in review mode there can be buttons on the property statuses
                newProperty.transform.GetChild(1).AddComponent<Button>(); newProperty.transform.GetChild(2).AddComponent<Button>();
                newProperty.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => ReviewProperty(index, newIndex, newProperty, true));
                newProperty.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => ReviewProperty(index, newIndex, newProperty, false));
            }

            if (propertiesModified[i] == false || reviewMode == true) { // If there was no edit in database or user is in review mode, property statuse become gray
                newProperty.transform.GetChild(1).GetComponent<Image>().color = Color.gray;
                newProperty.transform.GetChild(2).GetComponent<Image>().color = Color.gray;
                continue;
            }
            if(beachProperties[i].status == true) { // Based on property status, the status indicator gets a color
                newProperty.transform.GetChild(1).GetComponent<Image>().color = Color.green;
                newProperty.transform.GetChild(2).GetComponent<Image>().color = Color.gray;
            } else {
                newProperty.transform.GetChild(2).GetComponent<Image>().color = Color.red;
                newProperty.transform.GetChild(1).GetComponent<Image>().color = Color.gray;
            }
        }
        if(reviewMode == false) { // If user is not in review mode already he can review the beach or search in calendar
            propertiesText.text = "Facilitățile de astăzi";
            GameObject reviewCalendar = Instantiate(reviewCalendarPrefab, propertiesContent.transform);
            reviewCalendar.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => ReviewButton());
            reviewCalendar.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => CalendarButton(beaches[index].name));
        }
    }
    private void SelectBeach(int index) { // Open selected beach panel
        currentPressedBeach = index;
        ButtonsManager.ToggleObject(scrollViews[1]);
        ButtonsManager.ToggleObject(scrollViews[0]);
        LoadBeachProperties(index);
        Debug.Log("Pressed Beach_" + index);
    }
    private void ReviewProperty(int beachIndex, int propertyIndex, GameObject property, bool mode) { // Based on type of button pressed in review mode, the property change
        beaches[beachIndex].GetComponent<Beach>().ModifyProperty(property.name, mode, propertyIndex);
        if(mode == true) { // Toggle between status indicator colors
            property.transform.GetChild(1).GetComponent<Image>().color = Color.green;
            property.transform.GetChild(2).GetComponent<Image>().color = Color.gray;
        } else {
            property.transform.GetChild(2).GetComponent<Image>().color = Color.red;
            property.transform.GetChild(1).GetComponent<Image>().color = Color.gray;
        }
    }
    private void ReviewButton() { // Enters review mode
        reviewMode = true;
        propertiesText.text = "Finalizează";
        scrollViews[1].transform.GetChild(1).GetComponent<Scrollbar>().value = 1;
        LoadBeachProperties(currentPressedBeach);
    }
    public void BackToBeaches() { // Returning to beach normal view and setting review mode false
        reviewMode = false;
    }
    private void CalendarButton(string beachText) { // Enters calendar
        CalendarManager calendarManager = GameObject.Find("CalendarManager").GetComponent<CalendarManager>();
        beachCalendar.SetActive(true);
        calendarManager.LoadCalendar(beachText, DateTime.Now);
    }
}
