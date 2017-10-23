using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Errors{

    //Consulting const
    public const string SAME_CITIES = "The from and to cities must be different";
    public const string DATE_FORMAT = "The date format is invalid";
    public const string DATE_PAST = "The day not be must of past";
    public const string NOT_PASSENGERS = "The number of passengers must be upper than 0";
    public const string NOT_DATE = "The date must have a value";    

    //Reserve const
    public const string NAME_EMPTY = "The name field is empty";
    public const string ID_EMPTY = "The id field is empty";
    public const string CARD_EMPTY = "The creditcard field is empty";
    public const string AGE_EMPTY = "The age field is empty";
    public const string AGE_LESS = "You must be of legal age to reserve";
    public const string RESERVE_SUCCESS = "Reserve process successful";
    public const string SAME_DATE = "You have a reserve for this day, reserve for other date";

    //Search const
    public const string NOT_ID = "The id field is empty, please write your Id";
    public const string NOT_REGISTRIES = "You dont have reservations";
}
