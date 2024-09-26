using Microsoft.Maui.LifecycleEvents;
using NaukaSlow.Model;
using System;

namespace NaukaSlow
{
    public partial class MainPage : ContentPage
    {
        public List<Slowo> pytania = [
                new Slowo { Id=0,slowoP="Ptak",slowoT="Bird"},
                new Slowo { Id=1,slowoP="Dywan",slowoT="Carpet"},
                new Slowo { Id=2,slowoP="Jabłko",slowoT="Apple"},
                new Slowo { Id=3,slowoP="Dywan",slowoT="Carpet"},
                new Slowo { Id=3,slowoP="Banan",slowoT="Banana"},
                new Slowo { Id=3,slowoP="Pomarańcz",slowoT="Orange"},


            ];
        public int Lives = 3;
        public int succesCounts;
        Slowo currentQuestion;

        public MainPage()
        {
            InitializeComponent();
            int random = new Random().Next(pytania.Count);
            currentQuestion = pytania[random];
            slowo.Text = currentQuestion.slowoP;


        }


        public void Sprawdz(object sender, EventArgs e)
        {
            if (currentQuestion.slowoT == tlumaczenie.Text)
            {
                succesCounts++;
                SuccesCount.Text = $"Przetłumaczono: {succesCounts}";
                DisplayAlert("Dobrze!", "Poprawna odpowiedź", "OK");
            }
            else
            {
                Lives--;

                if (Lives == 0)
                {
                    DisplayAlert("Koniec", $"Niestety przegrałeś/aś! Przetłumaczono poprawnie {succesCounts} słów", "OK");

                    Lives = 3;
                    succesCounts = 0;
                }
                else
                {
                    DisplayAlert("Niedobrze!", $"To nie jest poprawna odpowiedź. Poprawna odpowiedź to {currentQuestion.slowoT}. Pozostało Ci: {Lives} życia", "OK");
                }

                lives.Text = $"Życia: {Lives}";
                SuccesCount.Text = $"Przetłumaczono: {succesCounts}";
            }

            int random = new Random().Next(pytania.Count);

            currentQuestion = pytania[random];
            slowo.Text = currentQuestion.slowoP;
        }



    }

}
