using System.Collections.ObjectModel;
using System.Text.Json;

namespace Exam
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            Value.disciplines = new ObservableCollection<Discipline>();
        }

        protected virtual void OnAppearing()
        {
            base.OnAppearing();
            disciplineList.ItemsSource = Value.disciplines;
        }

        //protected virtual void DisAppearing()
        //{
        //    base.DisAppearing();
        //    disciplineList.ItemsSource = Value.disciplines;
        //}

        private async void Add(object sender, EventArgs e)
        {
            //Value.disciplines.Add(new Discipline { Predmet = Discipline.Text, AvgMonth = Convert.ToInt32(Avg.Text) });
            await Navigation.PushAsync(new Add());
            disciplineList.ItemsSource = Value.disciplines;
        }

        private async void Edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Edit(disciplineList.SelectedItem as Discipline));
            disciplineList.ItemsSource = Value.disciplines;
        }

        private void Delete(object sender, EventArgs e)
        {
            Discipline discipline = (Discipline)disciplineList.SelectedItem;
            if (discipline != null)
            {
                Value.disciplines.Remove(discipline);
            }
            disciplineList.ItemsSource = Value.disciplines;
        }

        string mainDir = FileSystem.Current.AppDataDirectory;
        private void Save(object sender, EventArgs e)
        {
            string JsonString = JsonSerializer.Serialize(Value.disciplines);
            StreamWriter sw = new StreamWriter(Path.Combine(mainDir, "disciplines.txt"));
            sw.WriteLine(JsonString);
            sw.Close();
        }

        private void Load(object sender, EventArgs e)
        {
            StreamReader sw = new StreamReader(Path.Combine(mainDir, "disciplines.txt"));
            string jsonString = sw.ReadLine();
            Value.disciplines = JsonSerializer.Deserialize<ObservableCollection<Discipline>>(jsonString);
            sw.Close();
            disciplineList.ItemsSource = Value.disciplines;
        }

        private void Avg(object sender, EventArgs e)
        {
           Discipline avgDisp = new Discipline();
           //int avg += avgDisp.AvgMonth;
            DisplayAlert("","","");
        }

        private void disciplineList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Discipline selectedItem;
            if (e.SelectedItem != null)
            {
                selectedItem = (Discipline)e.SelectedItem;
                AvgRage.Text = selectedItem.Predmet;
            }
        }
    }

}
