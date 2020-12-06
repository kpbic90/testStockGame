using System;
using System.Globalization;
using UnityEngine;

namespace Assets.Scripts.Engine.DataManagment
{
    public class SavedDataManager
    {
        public void SaveResetDate(DateTime date)
        {
            PlayerPrefs.SetString("LastResetDate",  date.ToString("dd.MM.yyyy HH:mm:ss"));
        }

        public DateTime GetLastResetDate()
        {
            if (!PlayerPrefs.HasKey("LastResetDate"))
                return DateTime.MinValue;

            var value = PlayerPrefs.GetString("LastResetDate");
            var date = DateTime.ParseExact(value, "dd.MM.yyyy HH:mm:ss", new CultureInfo("ru-RU"));
            return date;
        }
    }
}