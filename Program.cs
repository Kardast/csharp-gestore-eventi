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



public class Evento
{
    //attributi
    private string _titolo;
    private DateTime _data;

    //properties
    public string Titolo
    {
        get
        {
            return _titolo;
        }
        set
        {
            if (_titolo != "")
            {
                _titolo = value;
            }
        }
    }
    public DateTime Data
    {
        get
        {
            return _data;
        }
        set
        {
            if (_data >= DateTime.Now)
            {
                _data = value;
            }
        }
    }
    public int PostiMaxEvento{ get; }
    public int PostiPrenotati { get; private set; }

    //construttore
    public Evento(string _titolo, DateTime _data, int postiMaxEvento, int postiPrenotati)
    {
        Titolo = _titolo;
        Data = _data;
        if (postiMaxEvento > 0)
        {
            PostiMaxEvento = postiMaxEvento;
        }
        
        PostiPrenotati = 0;
    }

    //metodi
    public int PrenotaPosti(int inputPrenota)
    {
        //metodo che si occuperà di gestire i posti prenotati un evento
        if((PostiMaxEvento - PostiPrenotati) >= inputPrenota && Data >= DateTime.Now)
        {
            return PostiPrenotati += inputPrenota;
        }
        return 0;
    }

    public int DisdiciPosti(int inputDisdici)
    {
        //metodo che si occuperà di gestire i posti cancellati ad un evento
        if ((PostiPrenotati - inputDisdici) >= 0 && Data >= DateTime.Now)
        {
            return PostiPrenotati -= inputDisdici;
        }
        return 0;
    }

    public override string ToString()
    {
        //metodo che si occuperà di ritornare una stringa dalla data dell'evento
        return "data in stringa + titolo";
    }
}

//classe gestore eccezioni
public class gestoreEventiEccezioni
{
    //gestirà le eccezioni
}