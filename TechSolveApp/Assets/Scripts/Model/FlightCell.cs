using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightCell : MonoBehaviour
{
    public Text departText;
    public Text arriveText;
    public Text chargeText;
    public System.DateTime flightDate;
    public string departHour = "";
    public string arriveHour = "";
    public int charge = 0;
    public int weekendCharge = 0;
    public int currentCharge = 0;

    private ReserveFlightView reserveView;

    public void Start()
    {
        reserveView = GameObject.FindObjectOfType<ReserveFlightView>();
        departText.text = departHour;
        arriveText.text = arriveHour;
        if (ConsultingFlightsController.dateToFlight.DayOfWeek == System.DayOfWeek.Saturday || ConsultingFlightsController.dateToFlight.DayOfWeek == System.DayOfWeek.Sunday)
        {            
            currentCharge = weekendCharge * ConsultingFlightsController.passengersToFlight;
            chargeText.text = "$" + currentCharge.ToString();
            GameObject.FindObjectOfType<ReserveFlightController>().ChargeAmount = currentCharge;
        }
        else
        {
            currentCharge = charge * ConsultingFlightsController.passengersToFlight;
            chargeText.text = "$" + currentCharge.ToString();
            GameObject.FindObjectOfType<ReserveFlightController>().ChargeAmount = currentCharge;
        }        
    }

    public void ReserveTicket()
    {
        reserveView.ShowReservePanel();
        GameObject.FindObjectOfType<ReserveFlightController>().UpdateCharge(this);
    }
}
