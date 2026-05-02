using UnityEngine;
using System.Collections.Generic;
using System;

public class Beach : MonoBehaviour {

    /* Attributes */

    private Dictionary<string, List<(string description, bool status)>> beachProperties = new Dictionary<string, List<(string description, bool status)>>(); // Attribute for beaches parameters list (based on date)
    private Dictionary<string, List<bool>> propertiesModified = new Dictionary<string, List<bool>>(); // Attribute for checking if a property was modified (based on date)
    private Dictionary<string, float> rank = new Dictionary<string, float>(); // Attribute for beach rank (based on date)

    /* Custom methods */

    public void AddProperty(string date, string description, bool status) { // Adding a beach property *needs database implementation*
        if (!beachProperties.ContainsKey(date)) {
            beachProperties[date] = new List<(string description, bool status)>();
            propertiesModified[date] = new List<bool>();
        }
        beachProperties[date].Add((description, status));
        propertiesModified[date].Add(true); // Needs to be false after database implementation
        // Adds in database a property for the beach based on date (Needs unit tests)
    }
    public void ModifyProperty(string date, string newDescription, bool newStatus, int index) { // Modifying a beach property *needs database implementation*
        beachProperties[date][index] = (newDescription, newStatus);
        propertiesModified[date][index] = true;
        // Modify in database a property for the beach based on date (Needs unit tests)
    }
    public void CopyBeachProperties(Dictionary<string, List<(string description, bool status)>> source, Dictionary<string, List<bool>> sourceModified) { // Copying a set of properties from another beach *needs database implementation*
        beachProperties.Clear();
        propertiesModified.Clear();
        foreach (var property in source) {
            beachProperties[property.Key] = new List<(string description, bool status)>(property.Value); 
        }
        foreach (var property in sourceModified) {
            propertiesModified[property.Key] = new List<bool>(property.Value);
        }
        // Copy in database a set of properties from another beach based on date (Needs unit tests)
    }
    public void DeleteProperty(string date, int index) { // Deleting a beach property *needs database implementation*
        beachProperties[date].RemoveAt(index);
        propertiesModified[date].RemoveAt(index);
        // Delete in database a property for the beach based on date (Needs unit tests)
    }
    public void DeleteAllProperties() { // Deleting all beach properties *needs database implementation*
        beachProperties.Clear();
        propertiesModified.Clear();
        // Delete in database all properties for the beach based on date (Needs unit tests)
    }

    public void AddRank(string date, float newRank) { // Adding beach rank *needs database implementation*
        rank[date] = Mathf.Clamp(newRank, 0f, 4f);
        // Add in database beach rank (Needs unit tests)
    }

    /* Getters */

    public Dictionary<string, List<(string description, bool status)>> GetBeachProperties() { // Getter for beach properties
        return beachProperties;
    }
    public Dictionary<string, List<bool>> GetPropertiesModified() { // Getter for properties modified
        return propertiesModified;
    }
    public Dictionary<string, float> GetRank() { // Getter for beach rank
        return rank;
    }
}
