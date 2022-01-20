using ApiDepartamentosCrud2022.Data;
using ApiDepartamentosCrud2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDepartamentosCrud2022.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int id)
        {
            return
                this.context.Departamentos.SingleOrDefault(x => x.IdDepartamento == id);
        }

        public void InsertDepartamento(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento();
            dept.IdDepartamento = id;
            dept.Nombre = nombre;
            dept.Localidad = localidad;
            this.context.Departamentos.Add(dept);
            this.context.SaveChanges();
        }

        public void UpdateDepartamento(int id, string nombre, string localidad)
        {
            Departamento dept = this.FindDepartamento(id);
            dept.Nombre = nombre;
            dept.Localidad = localidad;
            this.context.SaveChanges();
        }

        public void DeleteDepartamento(int id)
        {
            Departamento dept = this.FindDepartamento(id);
            this.context.Departamentos.Remove(dept);
            this.context.SaveChanges();
        }
    }
}
