using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour {



    public Dictionary<string, string> errors = new Dictionary<string, string>()
    {
        { "sameCities", "The from and to cities must be different"},
        { "dateFormat", "The date format is invalid"},
        { "datePast", "The day not be must of past"},
        { "noPassengers", "The number of passengers must be upper than 0"}
    };    
}


