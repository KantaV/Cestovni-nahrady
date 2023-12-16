using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cestovni_nahrady
{
    internal class NavstivenyStat
    {
        private string nazevStatu="";
        private TimeSpan casVeState=TimeSpan.Zero;

        public string NazevStatu
        {
            get { return nazevStatu;}
            set { nazevStatu = value;}
        }

        public TimeSpan CasVeState
        { 
            get { return casVeState;}
            set { casVeState = value;}
        }

        public NavstivenyStat(string nazevStatu, TimeSpan casVeState)
        {
            this.nazevStatu = nazevStatu;
            this.casVeState = casVeState;
        }
    }
}
