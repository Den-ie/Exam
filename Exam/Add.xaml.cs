using System.Collections.ObjectModel;

namespace Exam;

public partial class Add : ContentPage
{
    public Add()
    {
        InitializeComponent();
       
    }
    private void AddClick(object sender, EventArgs e)
    {
        if (int.TryParse(Avg.Text, out int y))
        {
            Value.disciplines.Add(new Discipline { Predmet = Discipline.Text, AvgMonth = Convert.ToInt32(Avg.Text) });
        }
        else
        {
            DisplayAlert("Ошибка","Введите корректные данные","Ок");
        }
    }

    private async void ReturnClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}