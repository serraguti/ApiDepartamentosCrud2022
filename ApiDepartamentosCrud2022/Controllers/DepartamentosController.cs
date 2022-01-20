using ApiDepartamentosCrud2022.Models;
using ApiDepartamentosCrud2022.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiDepartamentosCrud2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Departamento>> GetDepartamentos()
        {
            return this.repo.GetDepartamentos();
        }

        [HttpGet("{id}")]
        public ActionResult<Departamento> FindDepartamento(int id)
        {
            return this.repo.FindDepartamento(id);
        }

        //PODEMOS TENER MULTIPLES METODOS POST, PUT O DELETE
        //INSERTAR CON OBJETO
        [HttpPost]
        public void InsertDepartamento(Departamento departamento)
        {
            this.repo.InsertDepartamento(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
        }

        //VAMOS A CREAR OTRO METODO POST, PERO CON PARAMETROS
        //SI TENEMOS MAS DE UN POST, DEBEMOS MAPEAR LA LLAMADA
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public void InsertarDepartamento(int id, string nombre, string localidad)
        {
            this.repo.InsertDepartamento(id, nombre, localidad);
        }

        [HttpPut]
        public void UpdateDepartamento(Departamento departamento)
        {
            this.repo.UpdateDepartamento(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
        }

        [HttpDelete("{id}")]
        public void DeleteDepartamento(int id)
        {
            this.repo.DeleteDepartamento(id);
        }
    }
}
