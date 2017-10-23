package com.techsolve.afcastroc.techsolvetools;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.util.Log;
import android.widget.DatePicker;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

import java.util.Calendar;

/**
 * Created by Andres on 22/10/2017.
 */

public class Picker extends DialogFragment {

    public int finalYear, finalMonth, finalDay;
    static final int DATE_DIALOG_ID = 100;

    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {

        Log.e("MainClass", "onCreateDialog");
        final Calendar calendar = Calendar.getInstance();
        finalYear = calendar.get(Calendar.YEAR);
        finalMonth = calendar.get(Calendar.MONTH);
        finalDay = calendar.get(Calendar.DAY_OF_MONTH);
        return new DatePickerDialog(UnityPlayer.currentActivity, datePickerListener, finalYear, finalMonth,finalDay);
    }

    private DatePickerDialog.OnDateSetListener datePickerListener = new DatePickerDialog.OnDateSetListener() {
        @Override
        public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
            Log.e("MainClass", "onDataSet");
            finalYear = year;
            finalMonth = month + 1;
            finalDay = dayOfMonth;

            String result = String.valueOf(finalDay) + "/" + String.valueOf(finalMonth) + "/" + finalYear ;

            UnityPlayer.UnitySendMessage("ConsultingPanel","GetAndroidCalendarData", result);
        }
    };
}
