using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorMatchingSystemAPP.Managers
{
    public class DischargeCalcuation
    {
        public DischargeCalcuation() { }
        public string rowName;
        public decimal calculatedGrams;
        public decimal calculatedKilograms;
        public decimal calculatedPounds;

        public string RowName { get { return rowName; } set { rowName = value; } }
        public decimal CalculatedGrams { get { return calculatedGrams; } set { calculatedGrams = value; } }
        public decimal CalculatedKilograms { get { return calculatedKilograms; } set { calculatedKilograms = value; } }
        public decimal CalculatedPounds { get { return calculatedPounds; } set { calculatedPounds = value; } }
    }

}
