// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Calculator.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Calculator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LifeQuote
{
    using System;

    public class Calculator
    {
        public enum Gender
        {
            Male,
            Female
        }

        private enum Country
        {
            England,
            Scotland,
            Wales,
            NorthernIreland,
            Ireland,
            Other
        }
        public decimal GetQuote(
            DateTime dateOfBirth,
            Gender gender,
            string postcode,
            bool smoker,
            int hoursExercise,
            bool children)
        {
            if (string.IsNullOrEmpty(postcode))
            {
                throw new ArgumentException("Postcode must be supplied");
            }

            var age = CalculateAge(dateOfBirth);
            var quote = gender == Gender.Male ? GetMaleBaseQuote(age) : GetFemaleBaseQuote(age);
            quote = CheckForMinimumQuote(quote);

            var country = GetCountry(postcode);

            quote = CalculateRegionalHealthIndex(quote, country);
            quote = CheckForMinimumQuote(quote);
            quote = CalculateOffspringPremium(quote, children);
            quote = CheckForMinimumQuote(quote);
            quote = CalculateSmokerPremium(quote, smoker);
            quote = CheckForMinimumQuote(quote);
            quote = CalculateHealthyLifestyleBonus(quote, hoursExercise);
            quote = CheckForMinimumQuote(quote);

            return quote;
        }

        private Country GetCountry(string postcode)
        {
            postcode = postcode.ToUpper();

            if (postcode.Contains("NI"))
            {
                return Country.NorthernIreland;
            }

            if (postcode.Contains("SC"))
            {
                return Country.Scotland;
            }

            if (postcode.Contains("WA"))
            {
                return Country.Wales;
            }

            if (postcode.Contains("IR"))
            {
                return Country.Ireland;
            }

            if (postcode.Contains("OT"))
            {
                return Country.Other;
            }

            return Country.England;
        }

        private decimal CheckForMinimumQuote(decimal quote)
        {
            return quote < 50 ? 50 : quote;
        }

        private decimal CalculateHealthyLifestyleBonus(decimal quote, int hoursExercise)
        {
            switch (hoursExercise)
            {
                case 0:
                    quote *= (decimal)1.2;
                    break;

                case 3:
                case 4:
                case 5:
                    quote *= (decimal)0.7;
                    break;

                case 6:
                case 7:
                    quote *= (decimal)0.5;
                    break;

                default:
                    break;
            }

            if (hoursExercise > 7)
            {
                quote *= (decimal)1.5;
            }

            return quote;
        }

        private decimal CalculateSmokerPremium(decimal quote, bool smoker)
        {
            if (smoker)
            {
                return quote * 3;
            }

            return quote;
        }

        private decimal CalculateOffspringPremium(decimal quote, bool children)
        {
            if (children)
            {
                return quote * (decimal)1.5;
            }

            return quote;
        }

        private decimal CalculateRegionalHealthIndex(decimal quote, Country country)
        {
            switch (country)
            {
                case Country.England:
                    quote += 0;
                    break;

                case Country.Scotland:
                    quote += 200;
                    break;

                case Country.Wales:
                    quote -= 100;
                    break;

                case Country.Ireland:
                    quote += 50;
                    break;

                case Country.NorthernIreland:
                    quote += 75;
                    break;

                default:
                    quote += 100;
                    break;
            }

            return quote;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private decimal GetMaleBaseQuote(int age)
        {
            decimal basequote = 50;

            if (age < 19)
            {
                basequote = 150;
            }

            if (age > 18 && age < 25)
            {
                basequote = 180;
            }

            if (age > 24 && age < 36)
            {
                basequote = 200;
            }

            if (age > 34 && age < 45)
            {
                basequote = 250;
            }

            if (age > 44 && age < 61)
            {
                basequote = 320;
            }

            if (age > 59)
            {
                basequote = 500;
            }

            return basequote;
        }

        private decimal GetFemaleBaseQuote(int age)
        {
            decimal basequote = 50;

            if (age < 19)
            {
                basequote = 100;
            }

            if (age > 18 && age < 25)
            {
                basequote = 165;
            }

            if (age > 24 && age < 36)
            {
                basequote = 180;
            }

            if (age > 34 && age < 45)
            {
                basequote = 225;
            }

            if (age > 44 && age < 61)
            {
                basequote = 315;
            }

            if (age > 59)
            {
                basequote = 485;
            }

            return basequote;
        }
    }
}
