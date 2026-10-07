using DatabaseApp.Models;
using DatabaseApp.Services;

namespace DatabaseApp
{
    public partial class MainPage : ContentPage
    {
        DatabaseService database;
        Estudiante estudianteSeleccionado = null;

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
                Numero = NumeroEntry.Text
            };

            await database.Guardar(estudiante);

            NombreEntry.Text = "";
            GrupoEntry.Text = "";
            RFCEntry.Text = "";
            NumeroEntry.Text = "";
            estudianteSeleccionado = null;

            EstudiantesCollection.ItemsSource =
                await database.ObtenerTodos();
        }

        private void OnSelectionChanged(object sender,
    SelectionChangedEventArgs e)
        {

            estudianteSeleccionado =
                e.CurrentSelection.FirstOrDefault() as Estudiante;

            if (estudianteSeleccionado != null)
            {
                NombreEntry.Text = estudianteSeleccionado.Nombre;
                GrupoEntry.Text = estudianteSeleccionado.Grupo;
            }
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (estudianteSeleccionado != null)
            {
                await database.Eliminar(estudianteSeleccionado);

                EstudiantesCollection.ItemsSource =
                    await database.ObtenerTodos();

                NombreEntry.Text = "";
                GrupoEntry.Text = "";

                estudianteSeleccionado = null;
            }
        }


    }

}
