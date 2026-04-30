using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeachManager : MonoBehaviour {

    /* Attributes */

    [SerializeField] private GameObject beachContent; // Attribute for beach panel content
    [SerializeField] private GameObject beachPrefab; // Attribute that represents the standard form of a beach
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
        for(int i = 0; i < currentPressedZone * 3 + 1; i++) { // Example of implementation
            GameObject newBeach = Instantiate(beachPrefab, beachContent.transform);

            newBeach.name = "Beach_" + i; // Take the name from the database *needs database implementation*
            newBeach.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newBeach.name;

            newBeach.AddComponent<Beach>();
            Beach currentBeachScript = newBeach.GetComponent<Beach>();

            currentBeachScript.AddRank(i / 2); // Example of adding rank *needs database implementation*

            for(int j = 0; j < 20; j++) { // Example of adding properties *needs database implementation*
                currentBeachScript.AddProperty("Property_" + j, j % 2 == 0);
            }

            int index = i;
            newBeach.GetComponent<Button>().onClick.AddListener(() => SelectBeach(index)); // Adding the correspondent index
            newBeach.transform.GetChild(1).GetComponent<Image>().color = statusColors[Mathf.FloorToInt(currentBeachScript.GetRank() + 0.5f)]; // Adding status color
            // newBeach.transform.GetChild(2).GetComponent<Image>().sprite = something; // Need to add image from database (most probably)
            beaches.Add(newBeach);
        }
    }
    private void SelectBeach(int index) { // Open selected beach panel
        currentPressedBeach = index;
        Debug.Log("Pressed Beach_" + index);
    }
}
