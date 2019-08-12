using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class AmountPlayers
    {
        public static int amountOfPlayers;

        public static void SetAmountOfPlayers(int amount)
        {
            amountOfPlayers = amount;
        }

        public static int GetAmountOfPlayers()
        {
            return amountOfPlayers;
        }
    }
}
