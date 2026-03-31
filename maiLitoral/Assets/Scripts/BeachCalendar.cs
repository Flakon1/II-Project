
using TMPro;
using UnityEngine;

public class BeachCalendar : MonoBehaviour
{
    public TMP_Text monthText;
    public TMP_Text selectedDateText;

    private int currentMonth = 7;
    private int currentYear = 2026;

    void Start()
    {
        UpdateMonthText();
        selectedDateText.text = "Selected date: none";
    }

    void UpdateMonthText()
    {
        string[] months =
        {
            "", "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        monthText.text = months[currentMonth] + " " + currentYear;
    }

    public void SelectDay(int day)
    {
        string selectedDate = day + "/" + currentMonth + "/" + currentYear;
        selectedDateText.text = "Selected date: " + selectedDate;
        Debug.Log("Selected date: " + selectedDate);
    }

    public void NextMonth()
    {
        currentMonth++;

        if (currentMonth > 12)
        {
            currentMonth = 1;
            currentYear++;
        }

        UpdateMonthText();
    }

    public void PreviousMonth()
    {
        currentMonth--;

        if (currentMonth < 1)
        {
            currentMonth = 12;
            currentYear--;
        }

        UpdateMonthText();
    }
}