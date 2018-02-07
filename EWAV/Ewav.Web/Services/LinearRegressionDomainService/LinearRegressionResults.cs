﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWAV.Web.Services
{
    /// <summary>
    /// Linear Regression Results Class. Local representation of EpiInfos RegressionResults class
    /// </summary>
    public class LinearRegressionResults
    {

        private List<VariableRow> variables;

        public List<VariableRow> Variables
        {
            get { return variables; }
            set { variables = value; }
        }
        private double correlationCoefficient;

        public double CorrelationCoefficient
        {
            get { return correlationCoefficient; }
            set { correlationCoefficient = value; }
        }
        private int regressionDf;

        public int RegressionDf
        {
            get { return regressionDf; }
            set { regressionDf = value; }
        }
        private double regressionSumOfSquares;

        public double RegressionSumOfSquares
        {
            get { return regressionSumOfSquares; }
            set { regressionSumOfSquares = value; }
        }
        private double regressionMeanSquare;

        public double RegressionMeanSquare
        {
            get { return regressionMeanSquare; }
            set { regressionMeanSquare = value; }
        }
        private double regressionF;

        public double RegressionF
        {
            get { return regressionF; }
            set { regressionF = value; }
        }
        private int residualsDf;

        public int ResidualsDf
        {
            get { return residualsDf; }
            set { residualsDf = value; }
        }
        private double residualsSumOfSquares;

        public double ResidualsSumOfSquares
        {
            get { return residualsSumOfSquares; }
            set { residualsSumOfSquares = value; }
        }
        private double residualsMeanSquare;

        public double ResidualsMeanSquare
        {
            get { return residualsMeanSquare; }
            set { residualsMeanSquare = value; }
        }
        private int totalDf;

        public int TotalDf
        {
            get { return totalDf; }
            set { totalDf = value; }
        }
        private double totalSumOfSquares;

        public double TotalSumOfSquares
        {
            get { return totalSumOfSquares; }
            set { totalSumOfSquares = value; }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }
        private LinRegressionResults regressionResults;

        public LinRegressionResults RegressionResults
        {
            get { return regressionResults; }
            set { regressionResults = value; }
        }

    }
}