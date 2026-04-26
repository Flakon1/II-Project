using UnityEngine;

public class BeachPropertiesNavigationManager : MonoBehaviour {
    [SerializeField] private GameObject zoneBeaches;
    [SerializeField] private GameObject beachProperties;
    [SerializeField] private GameObject[] propertyPanels;

    // Open selected beach properties panel
    public void OpenBeachProperties(int index) {
        zoneBeaches.SetActive(false);
        beachProperties.SetActive(true);
        for (int i = 0; i < propertyPanels.Length; i++) {
            propertyPanels[i].SetActive(i == index);
        }
    }

    // Go back to beaches list
    public void BackToBeaches() {
        beachProperties.SetActive(false);
        zoneBeaches.SetActive(true);
        for (int i = 0; i < propertyPanels.Length; i++) {
            propertyPanels[i].SetActive(false);
        }
    }
}