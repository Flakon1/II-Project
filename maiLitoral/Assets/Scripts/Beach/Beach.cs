using UnityEngine;
using System.Collections.Generic;

public class Beach : MonoBehaviour {

    /* Attributes */

    private List<(string description, bool status)> beachProperties = new List<(string description, bool status)>(); // Attribute for beaches parameters list
    private float rank; // Attribute for beach rank

    /* Custom methods */

    public void AddProperty(string description, bool status) { // Adding a beach property *needs database implementation*
        beachProperties.Add((description, status));
        // Adds in database a property for the beach
    }
    public void ModifyProperty(string newDescription, bool newStatus, int index) { // Modifying a beach property *needs database implementation*
        beachProperties[index] = (newDescription, newStatus);
        // Modify in database a property for the beach
    }
    public void CopyBeachProperty(List<(string description, bool status)> source) { // Copying a set of properties from another beach *needs database implementation*
        beachProperties.Clear();
        beachProperties.AddRange(source);
        // Copy in database a set of properties from another beach
    }
    public void DeleteProperty(int index) { // Deleting a beach property *needs database implementation*
        beachProperties.RemoveAt(index);
        // Delete in database a property for the beach
    }
    public void DeleteAllProperties() { // Deleting all beach properties *needs database implementation*
        beachProperties.Clear();
        // Delete in database all properties for the beach
    }

    public void AddRank(float newRank) { // Adding beach rank *needs database implementation*
        rank = newRank;
        if (rank < 0) rank = 0;
        if (rank > 4) rank = 4;
        // Add in database beach rank
    }

    /* Getters */

    public List<(string description, bool status)> GetBeachProperties() { // Getter for beach properties
        return beachProperties;
    }
    public float GetRank() { // Getter for beach rank
        return rank;
    }
}
