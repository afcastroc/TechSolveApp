using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchReservationModel : MonoBehaviour {

    public static SearchReservationModel instance;

    public SearchReservationModel()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public ReserveFlightModel.ReserveData[] SearchReservations(string id)
    {
        ReserveFlightModel.ReserveData[] userReservations = SaveLoadData.instance.SearchUserReservations(id);        
        return userReservations;
    }
}
