using AppFletesMueve.Data;
using AppFletesMueve.Models;
using Microsoft.EntityFrameworkCore;

namespace AppFletesMueve.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        // Fíjate aquí: es Task
        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            try
            {
                var existe = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == usuario.Email);

                if (existe != null)
                {
                    System.Diagnostics.Debug.WriteLine("El usuario ya existe.");
                    return false;
                }

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR DB REGISTRO: {ex.Message}");
                return false;
            }
        }

        // Fíjate aquí: es Task
        public async Task<Usuario?> Login(string email, string password)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                return usuario;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR DB LOGIN: {ex.Message}");
                return null;
            }
        }
    }
}