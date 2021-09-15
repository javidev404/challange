using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsApp.Models;

namespace CardsApp.Helpers
{
    public class CardHelpers
    {
        //Una Card es válida para operar si su fecha de Expiration es mayor al presente día
        public static bool IsCardValid(Card Card)
        {
            return Card.Expiration > DateTime.Now;
        }

        //Una Card se identifica de acuerdo a la Brand, número de Card, cardHolder y fecha de Expiration
        //Identificar si una Card es distinta a otra
        public static bool AreCardsEqual(Card Card1, Card Card2)
        {
            return Card1.Brand == Card2.Brand && Card1.Number == Card2.Number &&
                   Card1.cardHolder == Card2.cardHolder && Card1.Expiration == Card2.Expiration;
        }
    }
}
