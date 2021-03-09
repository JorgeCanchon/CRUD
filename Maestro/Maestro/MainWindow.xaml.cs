using Infraestructura;
using Logica;
using Logica.Interfaces;
using Modelo;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Maestro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PersonaManager _personaManager;
        public MainWindow()
        {
            InitializeComponent();
            IPersonaRepositorio personaRepositorio = new PersonaEFRepositorio();//new PersonaRepositorio();
            _personaManager = new PersonaManager(personaRepositorio);
            CargarDatos();
        }

        public void CargarDatos()
        {
            dgPersona.ItemsSource = _personaManager.ObtenerTodos();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var persona = new Modelo.Persona()
            {
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                NumeroIdentificacion = Convert.ToInt64(txtNumeroIdentificacion.Text),
                TipoIdentificacion = txtTipoIdentificacion.Text
            };

            if(_personaManager.InsertarPersona(persona))
                CargarDatos();
        }

        private void Eliminar(int id) 
        {
            if (_personaManager.EliminarPersona(id)) 
            {
                CargarDatos();
            }       
        }

        private void ActualizarPersona()
        {
            var persona = new Modelo.Persona()
            {
                IdPersona = 2,
                Nombres = "Test",
                Apellidos = "test2",
                FechaNacimiento = Convert.ToDateTime("06/04/1998"),
                TipoIdentificacion = "CC",
                NumeroIdentificacion =  111111111
            };

            if (_personaManager.ActualizarPersona(persona))
            {
                CargarDatos();
            }
        }

        private void dgPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar(1);
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            ActualizarPersona();
        }
    }
}
