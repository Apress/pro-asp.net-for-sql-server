using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Used to validate a condition; sort of like the old "Appliction.Assert". 
/// Think of this class as runtime UnitTesting.
/// </summary>
    public  static class TestCondition
    {

        public static void IsTrue(bool condition, string failMessage) {
            if (!condition) {
                AssertFailed(failMessage);
            }

        }
        
        public static void IsNotNull(object o, string failMessage)
        {
            if (o == null)
            {
                AssertFailed(failMessage);
            }

        }
        public static void IsNotEmptyString(string s, string failMessage)
        {
            if (s == string.Empty)
            {
                AssertFailed(failMessage);
            }

        }
        public static void IsNotNullOrEmptyString(string s, string failMessage) {
            if (!String.IsNullOrEmpty(s)) {
                AssertFailed(failMessage);
            }

        }
        public static void IsGreaterThanZero(int i, string failMessage)
        {

            if (i <= 0)
            {
                AssertFailed(failMessage);
            }
        }
        public static void IsGreaterThanZero(decimal i, string failMessage)
        {

            if (i <= 0)
            {
                AssertFailed(failMessage);
            }
        }
        // Function to test for Positive Integers.
        public static void IsNaturalNumber(String strNumber, string failMessage)
        {
            Regex regNotNaturalPattern = new Regex("[^0-9]");
            Regex regNaturalPattern = new Regex("0*[1-9][0-9]*");

            if (!regNotNaturalPattern.IsMatch(strNumber) &&
                regNaturalPattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);

            }
        }

        // Function to test for Positive Integers with zero inclusive

        public static void IsWholeNumber(string strNumber, string failMessage)
        {
            Regex regNotWholePattern = new Regex("[^0-9]");

            if (regNotWholePattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);
            }
        }

        // Function to Test for Integers both Positive & Negative

        public static void IsInteger(string strNumber, string failMessage)
        {
            Regex regNotIntPattern = new Regex("[^0-9-]");
            Regex regIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");

            if (regNotIntPattern.IsMatch(strNumber) &&
                regIntPattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);
            }
        }

        // Function to test whether the string is valid number or not
        public static void IsNumber(string strNumber, string failMessage)
        {
            Regex regNotNumberPattern = new Regex("[^0-9.-]");
            Regex regTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex regTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex regNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            if (regNotNumberPattern.IsMatch(strNumber) &&
                !regTwoDotPattern.IsMatch(strNumber) &&
                !regTwoMinusPattern.IsMatch(strNumber) &&
                regNumberPattern.IsMatch(strNumber))
            {
                AssertFailed(failMessage);
            }
        }

        // Function To test for Alphabets.

        public static void IsAlpha(string strToCheck, string failMessage)
        {
            Regex regAlphaPattern = new Regex("[^a-zA-Z]");

            if (regAlphaPattern.IsMatch(strToCheck))
            {
                AssertFailed(failMessage);

            }
        }

        public static void IsValidEmail(string email, string failMessage)
        {
            string emailPattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            Regex regEmailPattern = new Regex(emailPattern);
            if (regEmailPattern.IsMatch(email))
            {
                AssertFailed(failMessage);

            }

        }
        // Function to Check for AlphaNumeric.

        public static void IsAlphaNumeric(string strToCheck, string failMessage)
        {
            Regex regAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");

            if (regAlphaNumericPattern.IsMatch(strToCheck))
            {
                AssertFailed(failMessage);

            }
        }

        static void AssertFailed(string message)
        {
            throw new Exception(message);
        }
    }
