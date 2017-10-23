using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

public class ConsultingFlightsController : MonoBehaviour {

    private ConsultingFlightsView view;
    private ConsultingFlightsModel model;
    private List<string> cityNames;
    List<string> airports;

    public static System.DateTime dateToFlight;
    public static int passengersToFlight = 0;    
    public static string cityFrom;
    public static string cityTo;
    public static string airportFrom;
    public static string airportTo;

    //*********************************************************************** Monobehaviour Methods ********************************************************************//

    public void Start()
    {
        view = GameObject.FindObjectOfType<ConsultingFlightsView>();
        model = new ConsultingFlightsModel();
        StartingConsultingForm();
    }

    //*********************************************************************** Setup Methods ********************************************************************//

    public void StartingConsultingForm()
    {
        cityNames = new List<string>(model.airports.Keys);
        airports = new List<string>();
        view.from.AddOptions(cityNames);
        view.to.AddOptions(cityNames);
        UpdateAirportName(true);
        UpdateAirportName(false);
    }

    //*********************************************************************** Form Change Methods ********************************************************************//

    public void UpdateAirportName(bool isFrom)
    {
        string newAirportName = "";
        if (isFrom)
        {
            model.airports.TryGetValue(cityNames[view.from.value], out newAirportName);
            view.airportFrom.text = newAirportName;
            cityFrom = cityNames[view.from.value];
            airportFrom = newAirportName;
        }
        else
        {
            model.airports.TryGetValue(cityNames[view.to.value], out newAirportName);
            view.airportTo.text = newAirportName;
            cityTo = cityNames[view.to.value];
            airportTo = newAirportName;
        }        
    }

    //*********************************************************************** Revision Methods ********************************************************************//

    public void CheckFormInfo()
    {
        if (view.from.value == view.to.value)
        {            
            Popups.popupManager.ShowPopup(false, Errors.SAME_CITIES);
            return;
        }
        if (!string.IsNullOrEmpty(view.date.text))
        {
            if (!CheckDateFormat(view.date.text))
            {
                return;
            }
        }
        else
        {
            Popups.popupManager.ShowPopup(false, Errors.NOT_DATE);
            return;
        }
        int passengers = 0;
        if (int.TryParse(view.nOfPassengers.text, out passengers))
        {
            if (passengers <= 0)
            {
                Popups.popupManager.ShowPopup(false, Errors.NOT_PASSENGERS);
                return;
            }
            else
            {
                passengersToFlight = passengers;                
            }
        }
        else
        {
            Popups.popupManager.ShowPopup(false, Errors.NOT_PASSENGERS);
            return;
        }        
        GameObject.FindObjectOfType<AppManager>().ChangeConsultingToTable();
    }

    public bool CheckDateFormat(string date)
    {        
        date = date.Replace("_","/");
        date = date.Replace("-", "/");
        
        try
        {
            date = System.DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);                      
        }
        catch (Exception e)
        {            
            int index = 0;
            string day = "";
            string month = "";
            string year = "";

            for (int i = 0; i < date.Length; i++)
            {
                if (date[i].ToString() == "/")
                {
                    index = i;
                }
            }
            year = date.Substring(index+1);
            date = date.Substring(0, index);
            for (int i = 0; i < date.Length; i++)
            {
                if (date[i].ToString() == "/")
                {
                    index = i;
                }
            }
            month = date.Substring(index+1);
            day = date.Substring(0,index);
            date = month + "/" + day + "/" + year;
        }        

        System.DateTime dDate;        
        System.DateTime today = System.DateTime.Today;        

        if (System.DateTime.TryParse(date, out dDate))
         {            
            if (dDate < today)
            {
                Popups.popupManager.ShowPopup(false, Errors.DATE_PAST);
                return false;
            }
            view.date.text = dDate.ToString("dd/MM/yyyy");
            dateToFlight = dDate;
            return true;            
         }
         else
         {            
            Popups.popupManager.ShowPopup(false, Errors.DATE_FORMAT);
            view.date.text = "";
            return false;
         }
    }

    public void ShowCalendar()
    {        
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass plugin = new AndroidJavaClass("com.techsolve.afcastroc.techsolvetools.MainClass");
            plugin.CallStatic("StartCalendar");            
        }
    }

    public void GetAndroidCalendarData(string data)
    {        
        view.date.text = data;
    }
}
