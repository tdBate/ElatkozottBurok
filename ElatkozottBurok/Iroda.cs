using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Iroda
    {
        private List<Fejleszto> fejlesztok;
        private Automata automataGep;

        public Iroda()
        {
            this.fejlesztok = new List<Fejleszto>();
            this.automataGep = new Automata();
        }

        public List<Fejleszto> Fejlesztok { get => fejlesztok; set => fejlesztok = value; }
        public Automata AutomataGep { get => automataGep; set => automataGep = value; }


        public void MunkanapSzimulacio(int orakSzama)
        {
            for (int i = 0; i < orakSzama; i++)
            {
                int count = 0;
                foreach (Fejleszto fejleszto in Fejlesztok)
                {
                    count++;
                    fejleszto.Dolgozik();
                    if (fejleszto.Koffeinszint < 20 || fejleszto.StresszSzint > 70)
                    {
                        if (AutomataGep.Keszlet.Any((Nassolnivalo item) => fejleszto.KedvencSnack == item.Nev))
                        {
                            if (AutomataGep.Vasarlas(fejleszto.KedvencSnack, fejleszto) != null)
                            {
                                fejleszto.Fogyaszt(AutomataGep.Keszlet.Find((Nassolnivalo item) => fejleszto.KedvencSnack == item.Nev));
                            }
                            
                        }
                        else 
                        {
                            //minimum keresés
                            Nassolnivalo min = AutomataGep.Keszlet[0];
                            foreach (Nassolnivalo item in AutomataGep.Keszlet)
                            {
                                if (item.Ar < min.Ar)
                                {
                                    min = item;
                                }
                            }

                            if (AutomataGep.Vasarlas(min.Nev, fejleszto) != null)
                            {
                                fejleszto.Fogyaszt(min);
                            }
                        }

                    }

                    Console.WriteLine($"\t{count}. fejlesztő: ${fejleszto.toString()}");
                }
            }
        }
    }
}