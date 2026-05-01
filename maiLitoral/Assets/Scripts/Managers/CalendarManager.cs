using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour {

    /* Attributes */

    [SerializeField] private List<GameObject> weeks; // Attribute for weeks in calendar
    [SerializeField] private GameObject dayPrefab; // Attribute that represents the standard form of a day
    [SerializeField] private TextMeshProUGUI currentDateText; // Attribute for current date text
    [SerializeField] private TextMeshProUGUI currentBeachText; // Attribute for current beach text

    /* Main Methods */

    /* Custom methods */
    
    public void NextPreviousMonth(int direction) {
        if(direction >= 0) {
            LoadCalendar(currentBeachText.text, DateTime.Now);
        } else {
            DateTime lastDate = DateTime.Now.AddMonths(direction);
            lastDate = lastDate.AddDays(DateTime.DaysInMonth(lastDate.Year, lastDate.Month) - lastDate.Day);
            LoadCalendar(currentBeachText.text, lastDate);
        }
    }
    public void LoadCalendar(string beachText, DateTime currentDate) { // Loading the calendar data
        for(int i = 0; i < 5; i++) {  // Destroying already shown days
            if(weeks[i].transform.childCount != 0) {
                foreach(Transform day in weeks[i].transform) {
                    Destroy(day.gameObject);
                }
            }
        }

        currentBeachText.text = beachText;
        CultureInfo culture = new CultureInfo("ro-RO");
        string text = currentDate.ToString("MMMM yyyy", culture); // Formatting the date text
        currentDateText.text = char.ToUpper(text[0]) + text.Substring(1);
        int totalDaysLastMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.AddMonths(-1).Month); // Last month number of days
        int totalDaysThisMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month); // Current month number of days
        DateTime firstDayInMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
        int firstDayInMon = (firstDayInMonth.DayOfWeek == DayOfWeek.Sunday) ? 6 : (int)firstDayInMonth.DayOfWeek - 1; // First day in month (For example, 1 may = 4 because it's friday)

        for (int i = 0; i < (totalDaysThisMonth + firstDayInMon); i++) {
            GameObject newDay = Instantiate(dayPrefab, weeks[i / 7].transform);
            if (firstDayInMon > i) { // Adding the days from the last month
                newDay.name = "Day_" + (totalDaysLastMonth - firstDayInMon + i + 1) + "_Last";
                newDay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (totalDaysLastMonth - firstDayInMon + i + 1).ToString();
                Destroy(newDay.GetComponent<Button>()); // Disabling the buttons on this days
                newDay.transform.GetChild(2).gameObject.SetActive(true);
                continue;
            }
            newDay.name = "Day_" + (i - firstDayInMon + 1);
            newDay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i - firstDayInMon + 1).ToString();
            if(firstDayInMon + currentDate.Day <= i) {
                Destroy(newDay.GetComponent<Button>()); // Disabling the buttons on this days
                newDay.transform.GetChild(2).gameObject.SetActive(true);
            }
        }

        int daysLeftInCalendar = 35 - (totalDaysThisMonth + firstDayInMon);
        for(int i = 0; i < daysLeftInCalendar; i++) { // Adding the days from the next month, if needed
            GameObject newDay = Instantiate(dayPrefab, weeks[4].transform);
            newDay.name = "Day_" + (i + 1) + "_New";
            newDay.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            Destroy(newDay.GetComponent<Button>()); // Disabling the buttons on this days
            newDay.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
