using UnityEngine;

public class TESTSCRIPT : MonoBehaviour {
    [SerializeField] private GameObject zoneList;
    // called when user types in the search bar
    public void Searching(string text) {
        zoneList.SetActive(true);
    }
    // called when user finishes editing the search bar
    public void StoppedSearching(string text) {
        zoneList.SetActive(false);
    }
}
