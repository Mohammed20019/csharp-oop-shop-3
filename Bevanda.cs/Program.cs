namespace Bevanda.cs
{
    public class Bevanda : Prodotto
    {
        // COSTANTI
        public const double GalloniPerLitro = 3.785; 
        private Litri capienzaAttuale;
        private readonly Litri capienzaMassimaLitri;
        private readonly string liquido;
        private readonly PH pH;

        // STATO
        private bool aperta;

        // PROPRIETÀ
        public Litri CapienzaAttuale { get => capienzaAttuale; private set => capienzaAttuale = value; }
        public Litri CapienzaMassimaLitri { get => capienzaMassimaLitri; private init => capienzaMassimaLitri = value; }
        public PH PH { get => pH; private init => pH = value; }
        public bool Aperta { get => aperta; private set => aperta = value; }
        public string Liquido { get => liquido; private init => liquido = value; }

        // COSTRUTTORI
        public Bevanda(string nome, string descrizione, string liquido, Litri contenutoMassimoLitri, PH pH, double prezzoBase, double iva)
            : base(nome, descrizione, prezzoBase, iva)
        {
            Liquido = LiquidoValido(liquido).ToLower();
            CapienzaMassimaLitri = contenutoMassimoLitri;
            PH = pH;
            Aperta = false;
            CapienzaAttuale = CapienzaMassimaLitri;
        }

        public void Bevi(Litri quantoBevi)
        {
            if (quantoBevi <= 0)
            { 
                throw new ArgumentOutOfRangeException(nameof(quantoBevi), "Non puoi bere niente o meno di niente!");
            }

            if (!Aperta)
            { 
                Console.WriteLine($"Provi a bere {quantoBevi} litri di {Liquido}... ma non hai aperto la bottiglia.");
                return;
            }

            Console.WriteLine($"Provi a bere {quantoBevi} litri di {Liquido}...");

            if (CapienzaAttuale == 0)
            { 
                Console.WriteLine($"La bottiglia di {Liquido} è vuota, non hai potuto berne il contenuto.");
            }
            else if (CapienzaAttuale - quantoBevi is <= 0)
            { 
                Console.WriteLine($"Hai bevuto {CapienzaAttuale} litri e svuotato tutto il contenuto della bottiglia, non c'è altro da bere");
                CapienzaAttuale = 0;
            }
            else
            { 
                CapienzaAttuale -= quantoBevi;
                Console.WriteLine($"Hai bevuto {quantoBevi} di {Liquido}. C'è ancora {CapienzaAttuale} di {Liquido} nella bottiglia");
            }
        }

        public void Riempi(Litri quantoRiempi)
        {
            if (quantoRiempi <= 0)
            { 
                throw new ArgumentOutOfRangeException(nameof(quantoRiempi), "Non puoi riempire la bottiglia con niente o meno di niente!");
            }

            if (!Aperta)
            { 
                Console.WriteLine($"Provi a riempire una bottiglia di {Liquido}, ma ti sei dimenticato di aprirla...");
                return;
            }

            Console.WriteLine($"Provi a riempire una bottiglia di {Liquido} con {quantoRiempi} litri...");

            if (CapienzaAttuale.Equals(CapienzaMassimaLitri))
            { 
                Console.WriteLine("La bottiglia è già piena.");
            }
            else if (CapienzaAttuale + quantoRiempi > CapienzaMassimaLitri)
            { 
                Console.WriteLine($"Hai riempito la bottiglia di {Liquido} fino alla massima capacità.");
                CapienzaAttuale = CapienzaMassimaLitri;
            }
            else
            { 
                Console.WriteLine($"Hai riempito la bottiglia di {Liquido} con {quantoRiempi} litri.");
                CapienzaAttuale += quantoRiempi;
            }
        }

        public void Apri()
        {
            Aperta = true;
        }

        public void Chiudi()
        {
            Aperta = false;
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Contiene {Liquido}
Capienza massima: {CapienzaMassimaLitri}
Capienza attuale: {CapienzaAttuale}
pH: {PH}";
        }

        public static double ConvertiInGalloni(double litri) => litri * GalloniPerLitro;

        // METODI PRIVATI
        private static string LiquidoValido(string liquido)
        {
            if (!string.IsNullOrWhiteSpace(liquido))
            {
                return liquido;
            }
            else
            {
                throw new LiquidoInvalido(nameof(liquido), $"{nameof(liquido)} non può essere vuoto o nullo.");
            }
        }
    }

    public class CapienzaInvalidaException : ArgumentOutOfRangeException
    {
        public CapienzaInvalidaException() : base() { }
        public CapienzaInvalidaException(string paramName) : base(paramName) { }
        public CapienzaInvalidaException(string paramName, string message) : base(paramName, message) { }
        public CapienzaInvalidaException(string message, Exception innerException) : base(message, innerException) { }
        public CapienzaInvalidaException(string paramName, object actualValue, string message) : base(paramName, actualValue, message) { }
    }

    public class LiquidoInvalido : ArgumentNullException
    {
        public LiquidoInvalido() : base() { }
        public LiquidoInvalido(string paramName) : base(paramName) { }
        public LiquidoInvalido(string paramName, string message) : base(paramName, message) { }
        public LiquidoInvalido(string message, Exception innerException) : base(message, innerException) { }
    }
}
