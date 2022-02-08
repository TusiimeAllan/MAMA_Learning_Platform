using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Developed by Indie Studio
///https://assetstore.unity.com/publishers/9268
///www.indiestd.com
///info@indiestd.com

public class CommonUtil {

		/// <summary>
		/// Convert the time in seconds to the string format "00:00".
		/// </summary>
		/// <returns>String Time Format.</returns>
		/// <param name="time">The time in seconds.</param>
		public static string TimeToString (float time)
		{
				int minutes = (int)(time / 60.0f);
				int seconds = (int)(time % 60.0f);
				string strMinutes = "";
				string strSeconds = "";

				if (minutes < 10) {
						strMinutes += "0";
				}
				if (seconds < 10) {
						strSeconds += "0";
				}

				strMinutes += minutes;
				strSeconds += seconds;

				return string.Format ("{0}:{1}", strMinutes, strSeconds);
		}

		/// <summary>
		/// Converts bool value true/false to int value 0/1.
		/// </summary>
		/// <returns>The int value.</returns>
		/// <param name="value">The bool value.</param>
		public static int TrueFalseBoolToZeroOne (bool value)
		{
				if (value) {
						return 1;
				}
				return 0;
		}

		/// <summary>
		/// Converts int value 0/1 to bool value true/false.
		/// </summary>
		/// <returns>The bool value.</returns>
		/// <param name="value">The int value.</param>
		public static bool ZeroOneToTrueFalseBool (int value)
		{
				if (value == 1) {
						return true;
				} else {
						return false;
				}
		}
}
