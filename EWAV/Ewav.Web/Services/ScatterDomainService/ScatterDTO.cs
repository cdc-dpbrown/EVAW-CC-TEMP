using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDC.ISB.EIDEV.Web.Services
{
    public class ScatterDataDTO
    {
        private List<NumericDataValue> dataValues;

        public List<NumericDataValue> DataValues
        {
            get { return dataValues; }
            set { dataValues = value; }
        }

        private LinRegressionResults regresResults;

        public LinRegressionResults RegresResults
        {
            get { return regresResults; }
            set { regresResults = value; }
        }

        private NumericDataValue maxValue;

        public NumericDataValue MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        private NumericDataValue minValue;

        public NumericDataValue MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
    }

    public class NumericDataValue
    {
        public decimal DependentValue { get; set; }
        public decimal IndependentValue { get; set; }
    }
}