using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PersonalID
{
    public class ID
    {
        private string personalID;

        private Gender personalGender;

        public ID(string inputId)
        {
            this.PersonalID = inputId;

            if (GetGenderSymbol()%2==0)
            {
                this.PersonalGender = Gender.Male;
            }
            else
            {
                this.PersonalGender = Gender.Female;
            }
        }
        
        public string PersonalID
        {
            get
            {
                return personalID;
            }
            private set
            {
                if (!EverySymbolIsDigit(value))
                {
                    throw new ArgumentException("Invalid personal ID. Not all symbols are digits!");
                }
                else if (!StringLengthIs_10(value))
                {
                    throw new ArgumentException("Invalid personal ID. Length must be 10 symbols!");
                }
                else if (!GivenDateIsValid(value))
                {
                    throw new ArgumentException("Invalid personal ID. Given date was not correct!");
                }
                else if (!GivenIDIsValid_Algorithm(value))
                {
                    throw new ArgumentException("Invalid personal ID!");
                }

                personalID = value;
            }
        }

        

        public Gender PersonalGender
        {
            get { return personalGender; }
            private set { personalGender = value; }
        }

        private string BirthDate => GetFormattedDate(this.PersonalID);

        //Methods-->

        private bool GivenIDIsValid_Algorithm(string value)
        {
            var array = value
                .Select(x => int.Parse(x.ToString()))
                .ToArray();

            double initialSum = array[0] * 2 + array[1] * 4 + array[2] * 8 + array[3] * 5 + array[4] * 10 + array[5] * 9 + array[6] * 7 + array[7] * 3 + array[8] * 6;

            double secondSum = Math.Floor(initialSum / 11) * 11;
            
            var controlNum = initialSum - secondSum;

            if (controlNum >= 10)
            {
                controlNum = 0;
            }

            if (controlNum == array.Last())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetBirthDate()
        {
            return this.BirthDate;
        }

        private int GetGenderSymbol()
        {
            var symbol = int.Parse(this.PersonalID.Substring(8, 1));

            return symbol;
        }

        private bool GivenDateIsValid(string date)
        {
            var formattedDate = GetFormattedDate(date);

            DateTime newDate;

            var result = DateTime.TryParseExact(formattedDate, "dd/MM/yyyy", null,
                DateTimeStyles.None, out newDate);

            return result;
        }

        private string GetFormattedDate(string date)
        {
            var day = date.Substring(4, 2);
            var month = date.Substring(2, 2);
            var year = $"19{date.Substring(0, 2)}";

            return $"{day}/{month}/{year}";
        }

        private bool StringLengthIs_10(string personalID)
        {
            return personalID.Length == 10;
        }

        private bool EverySymbolIsDigit(string personalID)
        {
            //return personalID.All(e => char.IsDigit(e));

            foreach (var item in personalID)
            {
                if (!char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}