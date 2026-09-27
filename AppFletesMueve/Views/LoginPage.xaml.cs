using AppFletesMueve.Models;
using AppFletesMueve.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppFletesMueve.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly UsuarioService _usuarioService;

        // 1. Constructor por defecto (para cuando haces "new LoginPage()" al cerrar sesión)
        public LoginPage()
        {
            InitializeComponent();
            try
            {
                var services = Application.Current?.Handler?.MauiContext?.Services;
                _usuarioService = services?.GetService<UsuarioService>() ?? throw new InvalidOperationException("No se pudo resolver UsuarioService");
            }
            catch (Exception ex)
            {
                // Manejar la excepción, por ejemplo, mostrar un mensaje de error
                DisplayAlert("Error", "No se pudo obtener el servicio de usuario: " + ex.Message, "Aceptar");
            }
        }

        public LoginPage(UsuarioService usuarioService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
        }

        private async void Ingresar_Clicked(object sender, EventArgs e)
        {
            var usuario = await _usuarioService.Login(
                txtEmail.Text,
                txtPassword.Text);

            if (usuario == null)
            {
                await DisplayAlert(
                    "Error",
                    "Usuario o contraseña incorrectos",
                    "Aceptar");

                return;
            }

            SesionUsuario.UsuarioId = usuario.UsuarioId;
            SesionUsuario.Nombre = usuario.Nombre;
            SesionUsuario.TipoUsuario = usuario.TipoUsuario;

            Preferences.Set("UsuarioId", usuario.UsuarioId);
            Preferences.Set("Nombre", usuario.Nombre);
            Preferences.Set("Apellido", usuario.Apellido);
            Preferences.Set("Email", usuario.Email);
            Preferences.Set("TipoUsuario", usuario.TipoUsuario);

            if (usuario.TipoUsuario == "CLIENTE")
            {
                Application.Current.MainPage =
                    new NavigationPage(
                        new MainPage());
            }
            else
            {
                Application.Current.MainPage =
                    new NavigationPage(
                        new HomeConductor());
            }
        }

        private async void Registro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage(_usuarioService));
        }
    }
}