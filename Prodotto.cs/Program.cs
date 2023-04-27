namespace Prodotto.cs
    public class Prodotto
{
    // ATTRIBUTI STATICI
    private static int prodottiCreati = 0;
    public static int ProdottiCreati { get => prodottiCreati; private set => prodottiCreati = value; }

    // ATTRIBUTI
    private readonly string codice;
    private readonly string nome;
    private string descrizione;
    private readonly double prezzoBase;
    private readonly double iva;

    // PROPRIETÀ
    public string Codice { get => codice; protected init => codice = value; }
    public string Nome { get => nome; protected init => nome = value; }
    public string Descrizione { get => descrizione; set => descrizione = value; }
    public double PrezzoBase { get => prezzoBase; protected init => prezzoBase = Math.Max(value, 0.0); }
    public double Iva { get => iva; protected init => iva = Math.Clamp(value, 0.0, 1.0); }
    public string NomeEsteso { get => Codice + Nome; }
    public double PrezzoConIva { get => PrezzoBase * (Iva + 1.0); }

    // COSTRUTTORI
    public Prodotto(string nome, string descrizione, double prezzoBase, double iva)
    {
        Codice = GeneraCodice();
        Nome = nome;
        Descrizione = descrizione;
        PrezzoBase = PrezzoValidato(prezzoBase);
        Iva = IvaValidata(iva);
        ProdottiCreati++;
    }

    // METODI PUBBLICI
    public override string ToString()
    {
        return $@"----- {Nome} [{NomeEsteso}] -----
Descrizione: {Descrizione}
Prezzo: {PrezzoBase:C}
Iva: {Iva * 100}%
Prezzo complessivo: {PrezzoConIva:C}";
    }

    public static double PrezzoBaseDaComplessivo(double prezzoComplessivo, double iva)
    {
        return prezzoComplessivo / (iva + 1);
    }

    // METODI PRIVATI
    protected static string GeneraCodice()
    {
        return new Random().Next(0, 100_000_000).ToString().PadLeft(8, '0');
    }
    protected static double PrezzoValidato(double prezzoBase)
    {
        if (prezzoBase >= 0)
        {
            return prezzoBase;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(prezzoBase), $"Il valore di {nameof(prezzoBase)} non può essere sotto zero");
        }
    }
    protected static double IvaValidata(double iva)
    {
        if (iva is >= 0 and <= 1)
        {
            return iva;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(iva), $"Il valore di {nameof(iva)} non può essere meno di 0 o più di 1");
        }
    }
}
}