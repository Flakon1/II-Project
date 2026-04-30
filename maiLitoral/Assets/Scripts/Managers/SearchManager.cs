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
        zones = zonesManager.GetComponent<ZonesManager>().GetZones();
        searchInputField.onValueChanged.AddListener(OnSearchValueChanged);
        autoCompleteText.text = "";
        ShowAllZones();
    } 
    private void OnSearchValueChanged(string currentText) { // Listener for updating the panels when typing
        UpdateSuggestion(currentText);
        FilterZones(currentText);
    }

    private void UpdateSuggestion(string currentText) { // Updating the panels when typing
        currentSuggestion = "";
        if (string.IsNullOrWhiteSpace(currentText)) {
            autoCompleteText.text = "";
            return;
        }
        string lowerText = currentText.ToLower();
        foreach(GameObject zone in zones) {
            string label = zone.name;
            if (label.ToLower().StartsWith(lowerText)) {
                currentSuggestion = label;
                break;
            }
        }
        if (string.IsNullOrEmpty(currentSuggestion)) {
            autoCompleteText.text = "";
            return;
        }
        if (currentSuggestion.Length == currentText.Length) {
            autoCompleteText.text = "";
            return;
        }
        autoCompleteText.text = currentSuggestion;
    }
    private void FilterZones(string currentText) { // Showing only the matched searched zones
        if (string.IsNullOrWhiteSpace(currentText)) {
            ShowAllZones();
            return;
        }
        string lowerText = currentText.ToLower();
        foreach(GameObject zone in zones) {
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