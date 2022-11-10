// See https://aka.ms/new-console-template for more information
//classe conferenza
public class Conferenza : Evento
{
    public string Relatore { get; private set; }
    public double Prezzo { get; private set; }

    public Conferenza (string titolo, DateOnly data, int postiMax, string relatore, double prezzo) : base (titolo, data, postiMax)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }

    //metodi
    public override string ToString()
    {
        //metodo che si occuperà di ritornare una stringa delle info dell'evento
        return Data.ToString("dd/MM/yyyy") + " - " + Titolo + " - " + Relatore + " - " + Prezzo.ToString("0.00") + " euro";
    }
}