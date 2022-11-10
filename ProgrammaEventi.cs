// See https://aka.ms/new-console-template for more information
public class ProgrammaEventi
{
    //properties
    public string Titolo { get; set; }
    public List<Evento> Eventi { get; }

    //costruttore
    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        Eventi = new List<Evento>();
    }

    //metodi
    public void AggiungiEvento(Evento evento)
    {
        Eventi.Add(evento);
    }

    public void ListaEventiPerData(DateOnly dataScelta)
    {
        Console.WriteLine("Gli eventi disponibili nella data scelta sono:");
        foreach (Evento evento in Eventi)
        {
            if (dataScelta == evento.Data)
            {
                Console.WriteLine(evento.Titolo);
            }
        }
    }
}