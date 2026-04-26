using UnityEngine;

public class ZoneNavigationManager : MonoBehaviour {
    [SerializeField] private GameObject zoneList;
    [SerializeField] private GameObject zoneBeaches;
    [SerializeField] private GameObject beachesParent;
    [SerializeField] private GameObject beachCalendar;
    [SerializeField] private GameObject[] beachesPanels;
    [SerializeField] private GameObject outsideClickOverlay;

    // Open selected zone panel
    public void OpenZonePanel(int index) {
        // Debug.Log("OPEN ZONE PANEL CALLED, index = " + index); 
        zoneBeaches.SetActive(true);
        outsideClickOverlay.SetActive(false);
        for (int i = 0; i < beachesPanels.Length; i++) {
            beachesPanels[i].SetActive(i == index);
        }
        zoneList.SetActive(false);
    }

    // Go back to zone list
    public void BackToZoneList() {
        beachesParent.SetActive(false);
        zoneList.SetActive(true);
        for (int i = 0; i < beachesPanels.Length; i++) {
            beachesPanels[i].SetActive(false);
        }
    }

    // Go back to first page
    public void BackToFirstPage() {
        zoneBeaches.SetActive(false);
        beachesParent.SetActive(false);
        zoneList.SetActive(false);
        beachCalendar.SetActive(true);
        for (int i = 0; i < beachesPanels.Length; i++) {
            beachesPanels[i].SetActive(false);
        }
    }

    public void ShowZoneList() {
        zoneList.SetActive(true);
        outsideClickOverlay.SetActive(true);
    }

    public void CloseZoneList() {
        zoneList.SetActive(false);
        zoneBeaches.SetActive(false);
        outsideClickOverlay.SetActive(false);
        beachCalendar.SetActive(true);
        for (int i = 0; i < beachesPanels.Length; i++) {
            beachesPanels[i].SetActive(false);
        }
    }
}