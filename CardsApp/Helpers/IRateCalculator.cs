using System;
using CardsApp.Models;

namespace CardsApp.Helpers
{
    public interface IRateCalculator
    {
        public double CalcularRatePorcentual(Brand Brand, DateTime date);
        public double CalcularRateNominal(Brand Brand, DateTime date, double importe);
    }
}