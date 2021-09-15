using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CardsApp.Models;

namespace CardsApp.Helpers
{
    public class RateCalculator : IRateCalculator
    {
        //Cada Brand tiene un modo de calcular una Rate por el servicio
        public double CalcularRatePorcentual(Brand Brand, DateTime date)
        {
            switch (Brand)
            {
                case Brand.SQUA:
                    return (double)date.Year / (double)date.Month;
                case Brand.SCO:
                    return (double)date.Month * 0.5;
                case Brand.PERE:
                    return (double) date.Month * 0.1;
            }
            throw new InvalidEnumArgumentException();
        }

        //Obtener por medio de un método la Rate de una operación informando Brand e importe
        public double CalcularRateNominal(Brand Brand, DateTime date, double importe)
        {
            return CalcularRatePorcentual(Brand, date) * importe;
        }
    }
}
