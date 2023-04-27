namespace csharp_oop_shop_3
Console.OutputEncoding = System.Text.Encoding.UTF8;

Bevanda bottigliaDiAcqua = new(nome: "Bottiglia di acqua",
                               descrizione: "Una bottiglia contenente un litro e mezzo di acqua",
                               liquido: "acqua",
                               contenutoMassimoLitri: -1.5,
                               pH: 7,
                               prezzoBase: Prodotto.PrezzoBaseDaComplessivo(2.99, 0.08),
                               iva: 0.08);

Bevanda succoDiArancia = new(nome: "Succo all'arancia",
                             descrizione: "Una bottiglia di succo di arance, ricco di Vitamina C",
                             liquido: "succo all'arancia",
                             contenutoMassimoLitri: 2,
                             pH: 2.46,
                             prezzoBase: Prodotto.PrezzoBaseDaComplessivo(4.99, 0.05),
                             iva: 0.05);

Bevanda teAllaPesca = new(nome: "Tè alla pesca",
                          descrizione: "Una bottiglia di tè alla pesca, perfetto per l'estate",
                          liquido: "tè alla pesca",
                          contenutoMassimoLitri: 1.5,
                          pH: 3.11,
                          prezzoBase: Prodotto.PrezzoBaseDaComplessivo(4.49, 0.06),
                          iva: 0.06);

Prodotto prodottoUtente = null;

string nome, descrizione;
double prezzoBase, iva;

bool continua = true;
while (continua) {
    try {
        Console.WriteLine("Inserisci un nome per il tuo prodotto: ");
        nome = Console.ReadLine();
        Console.WriteLine("Inserisci una descrizione per il tuo prodotto: ");
        descrizione = Console.ReadLine();
        Console.WriteLine("Inserisci un prezzo per il tuo prodotto: ");
        prezzoBase = double.Parse(Console.ReadLine());
Console.WriteLine("Inserisci una tassa IVA da 0 a 1 per il tuo prodotto: ");
        iva = double.Parse(Console.ReadLine());

prodottoUtente = new Prodotto(nome, descrizione, prezzoBase, iva);
continua = false;
    } catch (System.Exception) {
    Console.WriteLine("Questi input non sono validi! Riprova.");
}
}

List<Prodotto> prodotti = new() { bottigliaDiAcqua, succoDiArancia, teAllaPesca, prodottoUtente };
foreach (Prodotto p in prodotti)
{
    Console.WriteLine(p + Environment.NewLine);
}

Console.WriteLine($"Hai creato {Prodotto.ProdottiCreati} prodotti nel tuo programma!");