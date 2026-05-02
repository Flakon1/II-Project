using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchManager : MonoBehaviour {

    /* Attributes */

    [SerializeField] private GameObject zonesManager; // Attribute for zones manager
    [SerializeField] private TMP_InputField searchInputField; // Attribute for search input field
    [SerializeField] private TMP_Text autoCompleteText; // Attribute for auto complete text
    private List<GameObject> zones = new List<GameObject>(); // Attribute for zones list
    private string currentSuggestion = ""; // Attribute for current zone suggestion

    /* Main Methods */

    private void Start() {
        SearchInit(); // Setup the search suggestion
    }

    /* Custom methods */

    private void SearchInit() { // Setup the search suggestion
        zones = zonesManager.GetComponent<ZonesManager>().GetZones(); // Getting the available zones
        searchInputField.onValueChanged.AddListener(OnSearchValueChanged); // Adding the listener for input field
        autoCompleteText.text = ""; // Making sure the autocomplete is empty first
        ShowAllZones(); // Showing all zones in the start (because none was searched)
    } 
    private void OnSearchValueChanged(string currentText) { // Listener for updating the panels when typing
        UpdateSuggestion(currentText); // Updating the panels when typing
        FilterZones(currentText); // Showing only the matched searched zones
    }

    private void UpdateSuggestion(string currentText) { // Updating the panels when typing
        currentSuggestion = "";
        if (string.IsNullOrWhiteSpace(currentText)) { // What happends if there is no text
            autoCompleteText.text = "";
            return;
        }
        string lowerText = currentText.ToLower(); // Not case sensitive search
        foreach(GameObject zone in zones) {
            string label = zone.name;
            if (label.ToLower().StartsWith(lowerText)) {
                currentSuggestion = label;
                break;
            }
        }
        if (string.IsNullOrEmpty(currentSuggestion)) { // What happends if there is no suggestion
            autoCompleteText.text = "";
            return;
        }
        if (currentSuggestion.Length == currentText.Length) { // Do not autocomplete if the suggestion mathes the input field
            autoCompleteText.text = "";
            return;
        }
        autoCompleteText.text = currentSuggestion; // Filling the autocomplete text with the suggestion found
    }
    private void FilterZones(string currentText) { // Showing only the matched searched zones
        if (string.IsNullOrWhiteSpace(currentText)) {
            ShowAllZones();
            return;
        }
        string lowerText = currentText.ToLower();
        foreach(GameObject zone in zones) { // Showing only the relevant zone
            bool matches = zone.name.ToLower().Contains(lowerText);
            zone.SetActive(matches);
        }
    }
    private void ShowAllZones() { // Showing all zones
        foreach(GameObject zone in zones) {
            zone.SetActive(true);
        }
    }
    public void ShowZonesManager(bool mode) { // Activate / Deactivate the zones panel
        zonesManager.SetActive(mode);
    }
}