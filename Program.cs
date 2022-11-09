// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("Hello, World!");


//Info: Quando realizziamo un nuovo programma può avere senso prepararsi una prima eccezione relativa proprio al programma stesso.
//Una sorta di Eccezione principale da cui poi possiamo andare a generare eventuali specificazioni (classi figlie). Per esempio per il progetto di oggi GestoreEventiException
//Per la lavanderia LavanderiaException
//Dai cui poi ereditiamo, appunto:
//DetersivoInsufficenteException: LavanderiaException

//creare classe eccezioni gestoreEventiEccezioni

Console.WriteLine("inserisci nome evento");
string nomeEvento = Console.ReadLine();

Console.WriteLine("inserisci data evento (gg/mm/yyyy)");
DateOnly dataEvento = DateOnly.Parse((Console.ReadLine()));

Console.WriteLine("inserisci numero posti max evento");
int postiMaxEvento = Convert.ToInt32(Console.ReadLine());
try
{
    Evento evento1 = new Evento(nomeEvento, dataEvento, postiMaxEvento);
    Console.WriteLine("inserisci numero posti da prenotare");
    int postiDaPrenotare = Convert.ToInt32(Console.ReadLine());
    evento1.PrenotaPosti(postiDaPrenotare);
    Console.WriteLine("nome evento: {0}, data evento {1}, numero posti max: {2}, posti prenotati: {3}", evento1.Titolo, evento1.Data, evento1.PostiMax, evento1.PostiPrenotati);
    evento1.DisdiciPosti(postiDaPrenotare);
    Console.WriteLine("nome evento: {0}, data evento {1}, numero posti max: {2}, posti prenotati: {3}", evento1.Titolo, evento1.Data, evento1.PostiMax, evento1.PostiPrenotati);
    Console.WriteLine(evento1.ToString());
}
catch (GestoreEventiException e)
{
    Console.WriteLine(e.ToString());
}
