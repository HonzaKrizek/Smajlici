using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smajlici_2
{
    internal class Blok
    {
        private PulSmajl vlevo;
        private PulSmajl vpravo;
        private PulSmajl nahore;
        private PulSmajl dole;

        // kontructor
        public Blok(PulSmajl vlevo, PulSmajl vpravo, PulSmajl nahore, PulSmajl dole)
        {
            this.vlevo = vlevo;
            this.vpravo = vpravo;
            this.nahore = nahore;
            this.dole = dole;
        }

        // getters
        public PulSmajl Vlevo { get => vlevo; }
        public PulSmajl Vpravo { get => vpravo; }
        public PulSmajl Nahore { get => nahore; }
        public PulSmajl Dole { get => dole; }


        // pravotočivá rotace
        public void Rotace()
        {
            PulSmajl pomocna = nahore;
            nahore = vlevo;
            vlevo = dole;
            dole = vpravo;
            vpravo = pomocna;            
        }

        // svislé zrcadlení
        public void ZrcadleniSvisle()
        {
            PulSmajl pomocna = vlevo;
            vlevo = vpravo;
            vpravo = pomocna;
        }

        // vodorovné zrcadlení
        public void ZrcadleniVodorovne()
        {
            PulSmajl pomocna = nahore;
            nahore = dole;
            dole = pomocna;

        }

        // textová interperetace bloku pro soustavu bloků
        public String NahoreToString()
        {
            String text = "   ";
            if (nahore.Znak == Konstanty.PUSA)
            {
                text += Konstanty.PUSA_4;
            }
            else
            {
                text += Konstanty.OCI_2;
            }
            text += "   ";
            return text;
        }

        public String VlevoToString()
        {
            String text = " ";
            if (vlevo.Znak == Konstanty.PUSA)
            {
                text += Konstanty.PUSA_1;
            }
            else
            {
                text += Konstanty.OCI_1;
            }
            text += "  ";
            return text;
        }

        public String VpravoToString()
        {
            String text = "  ";
            if (vpravo.Znak == Konstanty.PUSA)
            {
                text += Konstanty.PUSA_2;
            }
            else
            {
                text += Konstanty.OCI_1;
            }
            text += " ";
            return text;
        }

        public String DoleToString()
        {
            String text = "   ";
            if (dole.Znak == Konstanty.PUSA)
            {
                text += Konstanty.PUSA_5;
            }
            else
            {
                text += Konstanty.OCI_2;
            }
            text += "   ";
            return text;
        }

        // textový výpis bloku
        public override string ToString()
        {
            return "Nahoře: " + Nahore + "\nVlevo: " + Vlevo + "\nVpravo: " + Vpravo + "\nDole: " + Dole;
        }

        // rovnost bloků
        public override bool Equals(object obj)
        {
            if ( this.dole.Equals(((Blok)obj).dole) 
                && this.nahore.Equals(((Blok)obj).nahore) 
                && this.vlevo.Equals(((Blok)obj).vlevo) 
                && this.vpravo.Equals(((Blok)obj).vpravo) )
            {
                return true;
            }

            return false;
        }
    }
}
