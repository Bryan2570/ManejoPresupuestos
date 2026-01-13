using Dapper;
using ManejoPresupuestos.Models;
using ManejoPresupuestos.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuestos.Controllers
{
    public class TiposCuentasController : Controller
    {

        private readonly IRepositoriosTiposCuentas repositoriosTiposCuentas;

        public TiposCuentasController(IRepositoriosTiposCuentas repositoriosTiposCuentas)
        {
            this.repositoriosTiposCuentas = repositoriosTiposCuentas;
        }

        public IActionResult Crear()
        {          
            return View();
        }


        [HttpPost]
        public IActionResult Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid) 
            { 
                return View(tipoCuenta);
            }

            tipoCuenta.UsuarioId = 1;
            repositoriosTiposCuentas.Crear(tipoCuenta);

            return View();
        }


    }
}
