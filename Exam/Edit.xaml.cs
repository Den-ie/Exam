using System.Collections.ObjectModel;

namespace Exam;

public partial class Edit : ContentPage
{
    Discipline discipline1 = new Discipline();
    Discipline disciplineOld = new Discipline();
	public Edit(Discipline discipline)
	{
		InitializeComponent();
        disciplineOld = discipline;
        Discipline.Text = discipline.Predmet;
        Avg.Text = discipline.AvgMonth.ToString();
    }

    private void EditClick(object sender, EventArgs e)
    {
        discipline1.Predmet = Discipline.Text;
        discipline1.AvgMonth = Convert.ToInt32(Avg.Text);
        Value.disciplines.Remove(disciplineOld);
        Value.disciplines.Add(discipline1);
    }

    private async void ReturnClick(object sender, EventArgs e)
    {

        await Navigation.PopAsync();
    }
}