//Alessio Donini
//4^f
//13/01/2022


using System;

namespace Verifica
{
    class Program
    {
        static void Main(string[] args)
        {
            string codtreno = "", tipo = "", nome = "", alimentazione = "";
            int numvagoni = 0, km = 0;
            SetDati(ref codtreno, ref tipo, ref nome, ref alimentazione, ref numvagoni, ref km);
            Passeggeri p = new Passeggeri(codtreno, tipo, nome, numvagoni, alimentazione, km);
            SetDati(ref codtreno, ref tipo, ref nome, ref alimentazione, ref numvagoni, ref km);
            Merci m = new Merci(codtreno, tipo, nome, numvagoni, alimentazione, km);
            p.CostoMezzoUtilizzato(); m.CostoMezzoUtilizzato();
            Console.WriteLine(p.ToString());
            Console.WriteLine(m.ToString());
            Console.ReadKey();
        }
        private static void SetDati(ref string codtreno, ref string tipo, ref string nome, ref string alimentazione, ref int numvagoni, ref int km)
        {
            bool isInt = false;
            Console.WriteLine("Inserisci il codice del treno");
            codtreno = Console.ReadLine();
            do
            {
                Console.WriteLine("Inserisci il tipo del treno");
                tipo = Console.ReadLine().ToLower();
            } while (tipo != "regionale" && tipo != "nazionale" && tipo != "internazionale");
            Console.WriteLine("Inserisci il nome del treno");
            nome = Console.ReadLine();
            do
            {
                try
                {
                    Console.WriteLine("Inserisci il numero di vagoni del treno");
                    numvagoni = Int32.Parse(Console.ReadLine());
                    isInt = true;
                }
                catch
                {
                    isInt = false;
                }
            } while (!isInt);
            Console.WriteLine("Inserisci l'alimentazione del treno");
            alimentazione = Console.ReadLine();
            isInt = false;
            do
            {
                try
                {
                    Console.WriteLine("Inserisci il numero di km percorsi dal treno");
                    km = Int32.Parse(Console.ReadLine());
                    
                    
                    isInt = true;
                }
                catch
                {
                    isInt = false;
                }
            } while (!isInt);

          
        }
    }
        
    class Treni //classe padre 
    {
        protected string codtreno;
        protected string tipo;
        protected string nome;
        protected int costo = 100000;
        protected int numvagoni;
        protected string alimentazione;
        protected int km;
        public virtual double CostoMezzoUtilizzato()
        {
            return costo;
        }
        public virtual int CostoUtilizzoMezzo()
        {
            return km;
        }
        public override string ToString()
        {
            return $"Codice Treno: {codtreno}\nTipo: {tipo}\nNome: {nome}\nCosto: {this.CostoMezzoUtilizzato()}\nNumero Di Vagoni: {numvagoni}\nAlimentazione: {alimentazione}\nCosto Utilizzo Del Mezzo Per {km}km: {this.CostoUtilizzoMezzo()} euro";
        }
    }
    class Passeggeri : Treni //classe figlia passeggeri
    {
        public Passeggeri(string codtreno, string tipo, string nome, int numvagoni, string alimentazione, int km)
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
            this.km = km;
        }
        public override double CostoMezzoUtilizzato()
        {
            return (costo * 1.25);
        }
        public override int CostoUtilizzoMezzo()
        {
            return (km * 150);
        }
    }
    class Merci : Treni// classe figlia Merci
    {
        public Merci(string codtreno, string tipo, string nome, int numvagoni, string alimentazione, int km)
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
            this.km = km;
        }
        public override double CostoMezzoUtilizzato()
        {
            return (costo * 1.35);
        }
        public override int CostoUtilizzoMezzo()
        {
            return (km * 100);
        }
    }
}



