using System;

namespace ElatkozottBurok
{
    public class Nassolnivalo
    {
        private string nev;
        private int koffeinLoket;
        private int stresszOldas;
        private int ar;

        public Nassolnivalo(string nev, int koffeinLoket, int stresszOldas, int ar)
        {
            //név
            if (nev == "" || nev == null)
            {
                nev = "Ismeretlen nassolnivaló";
            }
            else { this.nev = nev; }

            //koffeinlöket
            if (koffeinLoket < 0)
            {
                koffeinLoket = 0;
            }
            else if (koffeinLoket > 50)
            {
                koffeinLoket = 50;
            }

            //stresszoldás
            if (stresszOldas < 0)
            {
                stresszOldas = 0;
            }
            else if (stresszOldas > 30)
            {
                stresszOldas = 30;
            }

            //ár
            if (ar < 100)
            {
                ar = 100;
            }

            this.nev = nev;
            this.koffeinLoket = koffeinLoket;
            this.stresszOldas = stresszOldas;
            this.ar = ar;
        }

        public string Nev { get => nev; set
            {
                if (nev == "" || nev == null)
                {
                    nev = "Ismeretlen nassolnivaló";
                }
            } }
        public int KoffeinLoket { get => koffeinLoket; set => koffeinLoket = value; }
        public int StresszOldas { get => stresszOldas; set => stresszOldas = value; }
        public int Ar { get => ar; set => ar = value; }
    }
}