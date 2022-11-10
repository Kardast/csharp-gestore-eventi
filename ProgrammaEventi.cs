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

    //lista eventi
    public static void ListaEventi(List<Evento> Eventi)
    {
        Console.WriteLine("La lista degli eventi è: ");
        foreach (Evento evento in Eventi)
        {
            Console.WriteLine("---------");
            Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));

        }
        Console.WriteLine();
    }

    //numero eventi
    public void NumeroEventi()
    {
        int tot = 0;
        foreach (Evento evento in Eventi)
        {
            tot += 1;
        }
        Console.WriteLine("Il numero totale di eventi salvati è: {0}", tot);
    }

    //svuota lista eventi
    public void SvuotaLista()
    {
        Eventi.Clear();
        Console.WriteLine("La lista è stata svuotata");
    }

    //nome e data eventi
    public void NomeProgrammaEventi(ProgrammaEventi programmaEventi)
    {
        Console.WriteLine();
        Console.WriteLine("Nome programma eventi" + programmaEventi.Titolo);
        foreach (Evento evento in Eventi)
        {
            Console.WriteLine(evento.ToString());
        }
        Console.WriteLine();
    }
}