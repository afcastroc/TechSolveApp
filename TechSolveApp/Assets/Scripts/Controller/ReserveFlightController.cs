using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveFlightController : MonoBehaviour {
        
    private int chargeAmmount;  
    public int ChargeAmount { get { return chargeAmmount; } set { chargeAmmount = value; } }
    private ReserveFlightView view;
    private SaveLoadData saveInfo;
    private FlightCell currentCellInfo;

    //******************************************************************** Monobehaviour Methods ************************************************//

    private void Start()
    {
        view = GameObject.FindObjectOfType<ReserveFlightView>();
        saveInfo = new SaveLoadData();
    }

    //******************************************************************** Update Methods ************************************************//

    public void UpdateCharge(FlightCell info)
    {
        currentCellInfo = info;
        view.charge.text = "Charge: $ " + info.currentCharge.ToString();
    }

    //******************************************************************** Logic Methods ************************************************//

    public void MakeReserve()
    {
        if (CheckReserveForm())
        {            
            ReserveFlightModel.ReserveData dataToSave = new ReserveFlightModel.ReserveData();
            dataToSave.name = view.name.text;
            dataToSave.id = view.id.text;
            dataToSave.age = view.age.text;
            dataToSave.departHour = currentCellInfo.departHour;
            dataToSave.arriveHour = currentCellInfo.arriveHour;
            dataToSave.airportFrom = ConsultingFlightsController.airportFrom;
            dataToSave.airportTo = ConsultingFlightsController.airportTo;
            dataToSave.passengers = ConsultingFlightsController.passengersToFlight.ToString();
            dataToSave.dateToFlight = ConsultingFlightsController.dateToFlight.ToString();
            dataToSave.cityFrom = ConsultingFlightsController.cityFrom;
            dataToSave.cityTo = ConsultingFlightsController.cityTo;
            dataToSave.charge = chargeAmmount.ToString();
            if (SaveLoadData.instance.BuildAndSaveReserve(dataToSave))
            {
                ReserveSuccess();
            }
            else
            {
                Popups.popupManager.ShowPopup(false, Errors.SAME_DATE);
            }
        }
    }

    public void ReserveSuccess()
    {
        view.ShowReservingPopup();
    }

    //******************************************************************** Checker Methods ************************************************//

    public bool CheckReserveForm()
    {
        if (string.IsNullOrEmpty(view.name.text))
        {
            Popups.popupManager.ShowPopup(false, Errors.NAME_EMPTY);
            return false;
        }
        if (string.IsNullOrEmpty(view.id.text))
        {
            Popups.popupManager.ShowPopup(false, Errors.ID_EMPTY);
            return false;
        }
        if (string.IsNullOrEmpty(view.age.text))
        {
            Popups.popupManager.ShowPopup(false, Errors.AGE_EMPTY);
            return false;
        }
        else
        {
            if (int.Parse(view.age.text) < 18)
            {
                Popups.popupManager.ShowPopup(false, Errors.AGE_LESS);
            }
        }
        if (string.IsNullOrEmpty(view.creditCard.text))
        {
            Popups.popupManager.ShowPopup(false, Errors.CARD_EMPTY);
            return false;
        }
        return true;
    }
}
