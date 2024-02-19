using MvcCrudDepartamentosEF.Data;
using MvcCrudDepartamentosEF.Models;

namespace MvcCrudDepartamentosEF.Repositories
{
    public class RepositoryDepartamento
    {
        private DepartamentoContext context;

        public RepositoryDepartamento(DepartamentoContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.departamentos 
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int idDepartamento)
        {
            var consulta = from datos in this.context.departamentos
                           where datos.idDepartamento == idDepartamento
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertDepartamento(int idDepartamento, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.idDepartamento = idDepartamento;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.departamentos.Add(departamento);
            this.context.SaveChanges();
        }

        public void ModificarDepartamento(int idDepartamento, string nombre, string localidad)
        {
            Departamento departamento = this.FindDepartamento(idDepartamento);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.SaveChanges();
        }

        public void DeleteDepartamento(int idDepartamento)
        {
            Departamento departamento = this.FindDepartamento(idDepartamento);
            this.context.departamentos.Remove(departamento);
            this.context.SaveChanges();
        }
    }
}
