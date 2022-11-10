// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");


//Info: Quando realizziamo un nuovo programma può avere senso prepararsi una prima eccezione relativa proprio al programma stesso.
//Una sorta di Eccezione principale da cui poi possiamo andare a generare eventuali specificazioni (classi figlie). Per esempio per il progetto di oggi GestoreEventiException
//Per la lavanderia LavanderiaException
//Dai cui poi ereditiamo, appunto:
//DetersivoInsufficenteException: LavanderiaException

//creare classe eccezioni gestoreEventiEccezioni
//\n carattere di terminazione di una linea string


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


ProgrammaEventi programmaEventi = new ProgrammaEventi("Programma Eventi");

programmaEventi.AggiungiEvento(new Evento("concerto di Ika", DateOnly.Parse("24/03/2023"), 150));
programmaEventi.AggiungiEvento(new Evento("concerto di Sandro", DateOnly.Parse("27/03/2023"), 80));
programmaEventi.AggiungiEvento(new Evento("concerto di Paolo", DateOnly.Parse("24/03/2023"), 150));

void funzioneCase()
{
    Console.WriteLine("Vuoi fare altro? [si/no]");
    string inputUno = Console.ReadLine();
    if (inputUno == "si")
    {
        gestoreCasi();
    }
}

try
{
    gestoreCasi();
    //Console.WriteLine(evento1.ToString());
}
catch (GestoreEventiException e)
{
    Console.WriteLine(e.ToString());
}

void gestoreCasi()
{
    Console.WriteLine("Seleziona l'azione");
    Console.WriteLine("1: Aggiungi evento");
    Console.WriteLine("2: Prenota posti");
    Console.WriteLine("3: Ricerca eventi per data");
    Console.WriteLine("4: Disdici prenotazioni");
    Console.WriteLine("5: Visualizza tutti gli eventi");
    Console.WriteLine("6: Visualizza numero totale di eventi");
    Console.WriteLine("7: Svuota la lista eventi");
    Console.WriteLine("8: Stampa un programma eventi");


    int action = Convert.ToInt32(Console.ReadLine());

    switch (action)
    {
        case 1:
            //aggiungi evento
            Console.WriteLine("Per creare un nuovo evento inserire nome evento:");
            string nomeEvento = Console.ReadLine();

            Console.WriteLine("Inserire data evento (gg/mm/yyyy)");
            DateOnly dataEvento = DateOnly.Parse((Console.ReadLine()));

            Console.WriteLine("Inserire numero posti max evento");
            int postiMaxEvento = Convert.ToInt32(Console.ReadLine());

            Evento newEvento = new Evento(nomeEvento, dataEvento, postiMaxEvento);
            programmaEventi.AggiungiEvento(newEvento);
            Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", newEvento.Titolo, newEvento.Data, newEvento.PostiMax, newEvento.PostiPrenotati, (newEvento.PostiMax - newEvento.PostiPrenotati));

            funzioneCase();
            break;

        case 2:
            //prenota posti
            Console.WriteLine("Inserisci data evento (gg/mm/yyyy)");
            DateOnly dataEventoRicerca = DateOnly.Parse((Console.ReadLine()));
            programmaEventi.ListaEventiPerData(dataEventoRicerca);

            Console.WriteLine("Per quale evento ti vuoi prenotare? Inserisci titolo");
            string ricercaEvento = Console.ReadLine();
            Console.WriteLine("Quanti posti vuoi prenotare?");
            int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());

            foreach (Evento evento in programmaEventi.Eventi)
            {
                if (ricercaEvento == evento.Titolo)
                {
                    evento.PrenotaPosti(postiDaPrenotare);
                    Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));
                }
            }
            funzioneCase();
            break;

        case 3:
            //stampa lista per data
            Console.WriteLine("Inserisci data evento (gg/mm/yyyy)");
            DateOnly dataRicerca = DateOnly.Parse((Console.ReadLine()));
            programmaEventi.ListaEventiPerData(dataRicerca);
            funzioneCase();
            break;

        case 4:
            //disdici prenotazioni
            Console.WriteLine("Inserisci data evento (gg/mm/yyyy)");
            DateOnly dataEventoRicerca2 = DateOnly.Parse((Console.ReadLine()));
            programmaEventi.ListaEventiPerData(dataEventoRicerca2);

            Console.WriteLine("Per quale evento vuoi rimuovere prenotazioni? Inserisci titolo");
            string ricercaEvento2 = Console.ReadLine();

            foreach (Evento evento in programmaEventi.Eventi)
            {
                if (ricercaEvento2 == evento.Titolo)
                {
                    while (evento.PostiPrenotati > 0)
                    {
                        Console.WriteLine("Vuoi disdire prenotazioni? [si/no]");
                        string input = Console.ReadLine();
                        if (input == "si")
                        {
                            Console.WriteLine("Quante prenotazioni vuoi disdire?");
                            int postiDaDisdire = Convert.ToInt32(Console.ReadLine());
                            if (postiDaDisdire > evento.PostiPrenotati)
                            {
                                Console.WriteLine("Non sono presenti {0} posti prenotati", postiDaDisdire);
                            }
                            else
                            {
                                evento.DisdiciPosti(postiDaDisdire);
                                Console.WriteLine("nome evento: {0} \n data evento: {1} \n numero posti max: {2} \n posti prenotati: {3} \n posti rimanenti: {4}", evento.Titolo, evento.Data, evento.PostiMax, evento.PostiPrenotati, (evento.PostiMax - evento.PostiPrenotati));
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }
            funzioneCase();
            break;

        case 5:
            //lista totale eventi
            ProgrammaEventi.ListaEventi(programmaEventi.Eventi);
            funzioneCase();
            break;

        case 6:
            //conta eventi
            programmaEventi.NumeroEventi();
            funzioneCase();
            break;

        case 7:
            //svuota lista
            programmaEventi.SvuotaLista();
            funzioneCase();
            break;

        case 8:
            //programma eventi
            programmaEventi.NomeProgrammaEventi(programmaEventi);
            funzioneCase();
            break;
    }
}
