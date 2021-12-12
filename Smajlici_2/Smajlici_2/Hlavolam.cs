using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smajlici_2
{
    internal class Hlavolam
    {
        // pole bloků
        private Blok[,] pole;

        // různě barevné oči
        private static PulSmajl ociR = new PulSmajl(Konstanty.OCI, Konstanty.CERVENA);
        private static PulSmajl ociG = new PulSmajl(Konstanty.OCI, Konstanty.ZELENA);
        private static PulSmajl ociY = new PulSmajl(Konstanty.OCI, Konstanty.ZLUTA);
        private static PulSmajl ociB = new PulSmajl(Konstanty.OCI, Konstanty.MODRA);
        // různě barevné pusy
        private static PulSmajl pusaR = new PulSmajl(Konstanty.PUSA, Konstanty.CERVENA);
        private static PulSmajl pusaG = new PulSmajl(Konstanty.PUSA, Konstanty.ZELENA);
        private static PulSmajl pusaY = new PulSmajl(Konstanty.PUSA, Konstanty.ZLUTA);
        private static PulSmajl pusaB = new PulSmajl(Konstanty.PUSA, Konstanty.MODRA);
        // různé bloky
        private Blok blok11 = new Blok(ociG, pusaY, pusaR, ociR);
        private Blok blok12 = new Blok(pusaG, ociY, ociB, pusaB);
        private Blok blok13 = new Blok(pusaY, ociY, ociR, pusaB);
        private Blok blok21 = new Blok(pusaR, ociB, pusaR, ociG);
        private Blok blok22 = new Blok(pusaY, ociG, ociB, pusaR);
        private Blok blok23 = new Blok(ociG, pusaY, pusaB, ociR);
        private Blok blok31 = new Blok(ociB, pusaG, pusaB, ociY);
        private Blok blok32 = new Blok(ociY, pusaR, ociB, pusaB);
        private Blok blok33 = new Blok(ociG, pusaR, ociY, pusaG);

        // konstruktor
        public Hlavolam()
        {
            pole = new Blok[3, 3] { {blok11,blok12,blok13 }, {blok21,blok22,blok23 }, {blok31,blok32,blok33 } };
        }


        public int getVelikost()
        {
            return pole.Length;
        }

        // řešení nastavý všechny bloky tak, že zobrazí smajlíky
        public void Reseni()
        {
            foreach(Blok blok in pole)
            {
                while(!(blok.Nahore.Znak == Konstanty.PUSA && blok.Vpravo.Znak == Konstanty.PUSA))
                {
                    blok.Rotace();
                }
            }
        }


        // vypíše pole bloků barevně
        public void vypisBarevne()
        {
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.Length; j++)
                {
                    if (j < 3)
                    {
                        nastavBarvu(pole[i, j % 3].Nahore.Barva);
                        Console.Write(pole[i, j % 3].NahoreToString());
                    }
                    else if (j > 5)
                    {
                        nastavBarvu(pole[i, j % 3].Dole.Barva);
                        Console.Write(pole[i, j % 3].DoleToString());
                    }
                    else
                    {
                        nastavBarvu(pole[i, j % 3].Vlevo.Barva);
                        Console.Write(pole[i, j % 3].VlevoToString());

                        nastavBarvu(pole[i, j % 3].Vpravo.Barva);
                        Console.Write(pole[i, j % 3].VpravoToString());
                    }
                    if ((j % 3) == 2)
                    {
                        nastavBarvu(null);
                        Console.Write("\n");
                    }
                }
            }
        }

        // nastaví barvu vypisovaného textu
        private void nastavBarvu(String barva)
        {
            switch (barva)
            {
                case Konstanty.CERVENA:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Konstanty.ZELENA:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Konstanty.ZLUTA:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Konstanty.MODRA:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        // vypíše pole bloků jednobarevně
        public override string ToString()
        {
            String text = "";
            for(int i = 0; i < pole.GetLength(0); i++)
            {
                for(int j = 0; j < pole.Length; j++)
                {
                    if (j < 3)
                    {
                        text += pole[i, j % 3].NahoreToString();
                    }
                    else if (j>5)
                    {
                        text += pole[i, j % 3].DoleToString();
                    }
                    else
                    {
                        text += pole[i, j % 3].VlevoToString() + pole[i, j % 3].VpravoToString();
                    }

                    if((j % 3) == 2)
                    {
                        text += "\n";
                    }
                }
            }
            return text;
        }
    }
}
