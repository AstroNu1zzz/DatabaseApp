using DatabaseApp.Models;
using DatabaseApp.Services;

namespace DatabaseApp
{
    public partial class MainPage : ContentPage
    {
        DatabaseService database;

        public MainPage(DatabaseService db)
        {
            InitializeComponent();

            database = db;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            EstudiantesCollection.ItemsSource =
                await database.ObtenerTodos();
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            Estudiante estudiante = new()
            {
                Nombre = NombreEntry.Text,
                Grupo = GrupoEntry.Text,
                RFC = RFCEntry.Text,
                Numero = Convert.ToInt32(NumeroEntry.Text)
            };

            await database.Guardar(estudiante);

            NombreEntry.Text = "";
            GrupoEntry.Text = "";
            RFCEntry.Text = "";
            NumeroEntry.Text = "";

            EstudiantesCollection.ItemsSource =
                await database.ObtenerTodos();
        }
    }

}
