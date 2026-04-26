using UnityEngine;

public class TESTSCRIPT : MonoBehaviour {
    [SerializeField] private GameObject zoneList;
    [SerializeField] private GameObject outsideClickOverlay;
    // called when user types in the search bar
    public void Searching(string text) {
        zoneList.SetActive(true);
        outsideClickOverlay.SetActive(true);
    }
    // called when user finishes editing the search bar
    public void StoppedSearching(string text) {
        if (string.IsNullOrWhiteSpace(text)) {
            zoneList.SetActive(false);
        }
    }
}
