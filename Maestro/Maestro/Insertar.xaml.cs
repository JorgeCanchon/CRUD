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
    /// Interaction logic for Insertar.xaml
    /// </summary>
    public partial class Insertar : Page
    {
        private readonly PersonaManager _personaManager;
        public Insertar()
        {
            InitializeComponent();
            IPersonaRepositorio personaRepositorio = new PersonaRepositorio();
            _personaManager = new PersonaManager(personaRepositorio);
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

            _personaManager.InsertarPersona(persona);
        }
    }
}
