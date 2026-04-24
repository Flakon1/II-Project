using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class BeachManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField locationInput;
    public TMP_InputField typeInput;
    public TMP_InputField parkingInput;
    public TMP_InputField windInput;
    public TMP_InputField weatherInput;

    public TMP_InputField cleanlinessInput;
    public TMP_InputField safenessInput;
    public TMP_InputField crowdednessInput;

    public Toggle sunbedsToggle;
    public Toggle umbrellasToggle;
    public Toggle showersToggle;
    public Toggle toiletsToggle;
    public Toggle algaeToggle;
    public Toggle jellyfishToggle;
    public Toggle seaShellsToggle;
    public Toggle lifeguardsToggle;

    public List<BeachProperties> beaches = new List<BeachProperties>();

    public void BeachFromUI()
    {
        int cleanliness = ParseInputToInt(cleanlinessInput.text);
        int safeness = ParseInputToInt(safenessInput.text);
        int crowdedness = ParseInputToInt(crowdednessInput.text);

        BeachProperties beach = new BeachProperties(
            nameInput.text,
            locationInput.text,
            typeInput.text,
            cleanliness,
            safeness,
            sunbedsToggle.isOn,
            umbrellasToggle.isOn,
            showersToggle.isOn,
            toiletsToggle.isOn,
            parkingInput.text,
            algaeToggle.isOn,
            jellyfishToggle.isOn,
            seaShellsToggle.isOn,
            windInput.text,
            weatherInput.text,
            crowdedness,
            lifeguardsToggle.isOn
        );

        beaches.Add(beach);

        Debug.Log("Plaja adaugata: ");
    }

    private int ParseInputToInt(string value)
    {
        int result;

        if (int.TryParse(value, out result))
        {
            result = Mathf.Clamp(result, 1, 5);
            return result;
        }

        return 1;
    }
}