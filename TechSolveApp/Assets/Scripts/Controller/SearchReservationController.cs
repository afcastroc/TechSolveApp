using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchReservationController : MonoBehaviour {

    private SearchReservationsView view;

    private void Start()
    {
        view = GameObject.FindObjectOfType<SearchReservationsView>();
    }

    public void SearchUserReservations()
    {
        view.CleanResults();
        if (!string.IsNullOrEmpty(view.id.text))
        {
            ReserveFlightModel.ReserveData[] reservations = new SearchReservationModel().SearchReservations(view.id.text);
            if (reservations != null)
            {                
                view.UpdateCells(reservations);
            }
            else
            {                
                Popups.popupManager.ShowPopup(false, Errors.NOT_REGISTRIES);
            }
        }
        else
        {
            Popups.popupManager.ShowPopup(false, Errors.NOT_ID);
        }
    }    
}
