// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");

//snippet per date
//DateTime data = new DateTime(2022, 11, 9);

//if (DateTime.Today == data)
//{
//    Console.WriteLine("Data uguale");
//}

//if (DateTime.Today < data)
//{
//    Console.WriteLine("Data futura");
//}

//if (DateTime.Today > data)
//{
//    Console.WriteLine("Data passata");
//}


//ProgrammaEventi programmaEventi = new ProgrammaEventi("Programma Eventi");

//programmaEventi.AggiungiEvento(new Evento("concerto di Ika", DateOnly.Parse("24/03/2023"), 150));
//programmaEventi.AggiungiEvento(new Evento("concerto di Sandro", DateOnly.Parse("27/03/2023"), 80));
//programmaEventi.AggiungiEvento(new Evento("concerto di Paolo", DateOnly.Parse("24/03/2023"), 150));

Conferenza myConf = new Conferenza("ciao", DateOnly.Parse("12/12/2023"), 150, "sandro", 12.5);
Console.WriteLine(myConf.ToString());
Console.WriteLine();

try
{
    Console.WriteLine("Per creare un nuovo programma di eventi inserire nome:");
    string nomeProgrammaEvento = Console.ReadLine();
    ProgrammaEventi programmaEventiUser = new ProgrammaEventi(nomeProgrammaEvento);
    Console.WriteLine();

    Console.WriteLine("Quanti eventi vuoi aggiungere?");
    int numeroEventi = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    for (int i = 0; i < numeroEventi; i++)
    {
        Console.WriteLine("Per creare un nuovo evento inserire nome evento:");
        string nomeEvento = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Inserire data evento (gg/mm/yyyy)");
        DateOnly dataEvento = DateOnly.Parse((Console.ReadLine()));
        Console.WriteLine();

        Console.WriteLine("Inserire numero posti max evento");
        int postiMaxEvento = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Evento newEvento = new Evento(nomeEvento, dataEvento, postiMaxEvento);
        programmaEventiUser.AggiungiEvento(newEvento);
        Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", newEvento.Titolo, newEvento.Data, newEvento.PostiMax, newEvento.PostiPrenotati, (newEvento.PostiMax - newEvento.PostiPrenotati));
        Console.WriteLine();
    }

    menu(programmaEventiUser);
}
catch (GestoreEventiException e)
{
    Console.WriteLine(e.ToString());
}

void menu(ProgrammaEventi programmaEventi)
{
    Console.WriteLine("Seleziona l'azione");
    Console.WriteLine("1: Prenota posti");
    Console.WriteLine("2: Ricerca eventi per data");
    Console.WriteLine("3: Disdici prenotazioni");
    Console.WriteLine("4: Visualizza tutti gli eventi");
    Console.WriteLine("5: Visualizza numero totale di eventi");
    Console.WriteLine("6: Svuota lista");
    Console.WriteLine("7: Stampa un programma eventi");
    Console.WriteLine("8: Inserisci una conferenza");

    int action = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    switch (action)
    {
        case 1:
            //prenota posti
            Console.WriteLine("Inserisci data evento (gg/mm/yyyy)");
            DateOnly dataEventoRicerca = DateOnly.Parse((Console.ReadLine()));
            ProgrammaEventi.ListaEventi(programmaEventi.ListaEventiPerData(dataEventoRicerca));
            Console.WriteLine();
            Console.WriteLine("Per quale evento ti vuoi prenotare? Inserisci titolo");
            string ricercaEvento = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Quanti posti vuoi prenotare?");
            int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            foreach (Evento evento in programmaEventi.Eventi)
            {
                if (ricercaEvento == evento.Titolo)
                {
                    evento.PrenotaPosti(postiDaPrenotare);
                    Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));
                }
            }

            funzioneCase(programmaEventi);

            break;

        case 2:
            //ricerca eventi per data
            Console.WriteLine("Inserisci data evento (gg/mm/yyyy)");
            DateOnly dataRicerca = DateOnly.Parse((Console.ReadLine()));
            Console.WriteLine();
            List<Evento> listaFlitrata = programmaEventi.ListaEventiPerData(dataRicerca);
            ProgrammaEventi.ListaEventi(listaFlitrata);
            funzioneCase(programmaEventi);
            break;

        case 3:
            //disdici prenotazioni
            Console.WriteLine("Inserisci data evento (gg/mm/yyyy)");
            DateOnly dataEventoRicerca2 = DateOnly.Parse((Console.ReadLine()));
            Console.WriteLine();
            ProgrammaEventi.ListaEventi(programmaEventi.ListaEventiPerData(dataEventoRicerca2));
            Console.WriteLine("Per quale evento vuoi rimuovere prenotazioni? Inserisci titolo");
            string ricercaEvento2 = Console.ReadLine();
            Console.WriteLine();

            foreach (Evento evento in programmaEventi.Eventi)
            {
                if (ricercaEvento2 == evento.Titolo)
                {
                    while (evento.PostiPrenotati > 0)
                    {
                        Console.WriteLine("Vuoi disdire prenotazioni? [si/no]");
                        string inputDisdire = Console.ReadLine();
                        Console.WriteLine();

                        if (inputDisdire == "si")
                        {
                            Console.WriteLine("Quante prenotazioni vuoi disdire?");
                            int postiDaDisdire = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            if (postiDaDisdire > evento.PostiPrenotati)
                            {
                                Console.WriteLine("Non sono presenti {0} posti prenotati", postiDaDisdire);
                                Console.WriteLine();

                            }
                            else
                            {
                                evento.DisdiciPosti(postiDaDisdire);
                                Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));
                                Console.WriteLine();

                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }

            funzioneCase(programmaEventi);

            break;

        case 4:
            //stampa tutti gli eventi
            ProgrammaEventi.ListaEventi(programmaEventi.Eventi);
            Console.WriteLine();

            funzioneCase(programmaEventi);
            break;

        case 5:
            //stampa totale eventi
            programmaEventi.NumeroEventi();

            funzioneCase(programmaEventi);
            break;

        case 6:
            //svuota lista eventi
            programmaEventi.SvuotaLista();

            funzioneCase(programmaEventi);
            break;

        case 7:
            //stampa programma eventi
            programmaEventi.NomeProgrammaEventi(programmaEventi);

            funzioneCase(programmaEventi);
            break;

        case 8:
            //aggiungi conferenza
            Console.Write("Per creare una nuova conferenza inserire nome conferenza: ");
            string nomeConferenza = Console.ReadLine();

            Console.Write("Inserire data conferenza (gg/mm/yyyy): ");
            DateOnly dataConferenza = DateOnly.Parse((Console.ReadLine()));

            Console.Write("Inserire numero posti max evento: ");
            int postiMaxConferenza = Convert.ToInt32(Console.ReadLine());

            Console.Write("Inserire nome relatore: ");
            string nomeRelatoreConferenza = Console.ReadLine();

            Console.Write("Inserire prezzo: ");
            double prezzoConferenza = Convert.ToDouble(Console.ReadLine());

            Evento newEvento = new Conferenza(nomeConferenza, dataConferenza, postiMaxConferenza, nomeRelatoreConferenza, prezzoConferenza);
            programmaEventi.AggiungiEvento(newEvento);
            Console.WriteLine("\n nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}\n", newEvento.Titolo, newEvento.Data, newEvento.PostiMax, newEvento.PostiPrenotati, (newEvento.PostiMax - newEvento.PostiPrenotati));

            funzioneCase(programmaEventi);

            break;
    }
}
void funzioneCase(ProgrammaEventi programmaEventi)
{
    Console.WriteLine();

    Console.WriteLine("Vuoi fare altro? [si/no]");
    string inputUno = Console.ReadLine();
    if (inputUno == "si")
    {
        Console.WriteLine();
        menu(programmaEventi);
    }
}

