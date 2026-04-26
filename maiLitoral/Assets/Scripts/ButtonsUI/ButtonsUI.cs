using UnityEngine;
using TMPro;
using System.Collections.Generic;


[System.Serializable]
public class BeachItem
{
    public string name;
    public GameObject panel;
}

public class ButtonsUI : MonoBehaviour
{
    public TMP_InputField searchInput;
    public List<BeachItem> beaches;

    public void SearchBeach()
    {
        string text = searchInput.text.ToLower().Trim();

        foreach (var beach in beaches)
        {
            beach.panel.SetActive(false);
        }

        foreach (var beach in beaches)
        {
            if (beach.name.ToLower().Trim().Contains(text))
            {
                beach.panel.SetActive(true);

                RectTransform rt = beach.panel.GetComponent<RectTransform>();
                if (rt != null)
                {
                    rt.anchoredPosition = Vector2.zero;
                    rt.offsetMin = Vector2.zero;
                    rt.offsetMax = Vector2.zero;
                }

                return;
            }
        }

        Debug.Log("Nu s-a gasit plaja");
    }
    public void BackButtonProperties(){
        foreach (var beach in beaches){
            beach.panel.SetActive(false);


        }

    }
}