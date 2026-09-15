using System;
using System.Linq.Expressions;

namespace ElatkozottBurok
{
    public class Fejleszto
    {
        private string nev;
        private Munkakor munkakor;
        private int penz;
        private int koffeinSzint;
        private int stresszSzint;
        private bool kiegve;
        private string kedvencSnack;

        public Fejleszto(string nev, Munkakor munkakor, int penz, string kedvencSnack, int koffeinSzint, int stresszSzint)
        {
            this.nev = nev;
            this.munkakor = munkakor;
            this.penz = penz;
            this.koffeinSzint = koffeinSzint;
            this.stresszSzint = stresszSzint;
            this.kiegve = false;
            this.kedvencSnack = kedvencSnack;
        }

        public string Nev { get => nev; set => nev = value; }
        public Munkakor Munkakor { get => munkakor; set => munkakor = value; }
        public int Penz { get => penz; set  {
                if (value < 0)
                {
                    penz = 0;
                }
                else 
                {
                    penz = value;
                }
            } }
        public int Koffeinszint { get => koffeinSzint; set {
                if (value < 0) { koffeinSzint = 0; }
                else if (value >= 100) { koffeinSzint = 100; kiegve = true; }
                else { koffeinSzint = value; }
            }
        }
        public int StresszSzint { get => stresszSzint; set {
                if (value < 0) { stresszSzint = 0; }
                else if (value >= 100) { stresszSzint = 100; kiegve = true; }
                else { stresszSzint = value; }
            } }
        public bool Kiegve { get => kiegve; set => kiegve = value; }
        public string KedvencSnack { get => kedvencSnack; set => kedvencSnack = value; }

        public void Dolgozik() 
        {
            if (Kiegve) { Console.WriteLine("A fejlesztő ki van égve"); }
            else if (Munkakor == Munkakor.Junior)  
            {
                Koffeinszint -= 25;
                StresszSzint += 20;
            }
            else if (Munkakor == Munkakor.Senior)
            {
                Koffeinszint -= 15;
                StresszSzint += 10;
            }
            else if (Munkakor == Munkakor.DevOpsVarazslo)
            {
                Koffeinszint -= 10;
                StresszSzint += 25;
            }

            if (Koffeinszint < 15) { Console.WriteLine($"${Nev} agya lefagyott(BlueScreen), koffeinre van szüksége!"); }
        }

        public void Fogyaszt(Nassolnivalo elem)
        {
            if (KedvencSnack == elem.Nev)
            {
                Koffeinszint += elem.KoffeinLoket+5;
                StresszSzint -= (elem.StresszOldas*2);
            } else
            {
                Koffeinszint += elem.KoffeinLoket;
                StresszSzint -= elem.StresszOldas;
            }

        }
    }
}