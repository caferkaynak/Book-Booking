using bookbooking.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bookbooking.Common.ViewModels.CardV
{
    public class CardView
    {
        public Card Card { get; set; }
        public List<Card> Cards { get; set; }
        public int[] IdsToDelete { get; set; }
    }
}
