using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Automata
    {
        private int keszpenzKassza;
        private List<Nassolnivalo> keszlet;

        private bool elakadva;

        public Automata()
        {
            KeszpenzKassza =0;
            elakadva = false;
            keszlet = new List<Nassolnivalo>();
        }

        public int KeszpenzKassza { get => keszpenzKassza; set => keszpenzKassza = value; }
        public List<Nassolnivalo> Keszlet { get => keszlet; set => keszlet = value; }
        public bool Elakadva { get => elakadva; set => elakadva = value; }


        public void Feltolt(List<Nassolnivalo> ujelemek) 
        {
            Keszlet.AddRange(ujelemek);
        }

        public Nassolnivalo Vasarlas(string termekNev, Fejleszto vasarlo)
        {
            if (Elakadva)
            {
                vasarlo.StresszSzint += 15;
                return null;
            }

            if (!Keszlet.Exists((Nassolnivalo item) => item.Nev == termekNev))
            {
                return null;
            }

            Nassolnivalo termek = Keszlet.Find((Nassolnivalo item) => item.Nev == termekNev);

            if (vasarlo.Penz < termek.Ar)
            {
                Console.WriteLine("Nincs elég pénz");
                return null;
            }

            if (new Random().Next(0, 100) < 15)
            {
                Elakadva = true;
                vasarlo.Penz -= termek.Ar;
                vasarlo.StresszSzint += 30;
                return null;
            }
            else 
            {
                vasarlo.Penz -= termek.Ar;
                KeszpenzKassza += termek.Ar;
                Keszlet.Remove(termek);
                return termek;
            }
        }
    }
}