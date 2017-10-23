using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReserveInfoCell : MonoBehaviour {

    public Text date;
    public Text nameUser;
    public Text age;
    public Text from;
    public Text airFrom;
    public Text to;
    public Text airTo;
    public Text depart;
    public Text arrive;
    public Text passengers;
    public Text Charge;

    public void UpdateInfo(ReserveFlightModel.ReserveData data)
    {        
        System.DateTime dDate;
        System.DateTime.TryParse(data.dateToFlight, out dDate);
        date.text = dDate.ToString("dd/MM/yyyy");
        
        nameUser.text = data.name;
        age.text = data.age;
        from.text = data.cityFrom;
        airFrom.text = data.airportFrom;
        to.text = data.cityTo;
        airTo.text = data.airportTo;
        depart.text = data.departHour;
        arrive.text = data.arriveHour;
        passengers.text = data.passengers;
        Charge.text = "$ " + data.charge;
    }
}
