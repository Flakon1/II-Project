using UnityEngine;

public class ZoneNavigationManager : MonoBehaviour
{
    [SerializeField] private GameObject zoneList;
    [SerializeField] private GameObject beachesParent;
    [SerializeField] private GameObject[] beachesPanels;

    // Open selected zone panel
    public void OpenZonePanel(int index) {
        zoneList.SetActive(false);
        beachesParent.SetActive(true);

        for (int i = 0; i < beachesPanels.Length; i++) {
            beachesPanels[i].SetActive(i == index);
        }
    }

    // Go back to zone list
    public void BackToZoneList() {
        beachesParent.SetActive(false);
        zoneList.SetActive(true);

        for (int i = 0; i < beachesPanels.Length; i++) {
            beachesPanels[i].SetActive(false);
        }
    }
}