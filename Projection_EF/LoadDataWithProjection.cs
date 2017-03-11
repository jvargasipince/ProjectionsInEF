using System;
using System.Linq;
using Projection_EF.Projection;

namespace Projection_EF
{
    public class LoadDataWithProjection
    {
        static void Main(string[] args)
        {
            LoadDataEmployes();
        }

        static void LoadDataEmployes()
        {
            var AWEntitiesContext = new AdventureWorks2014Entities();


            var ListaEmpleadosProjection = AWEntitiesContext.EmployeeDepartmentHistories
                                            .Include("Employee")
                                            .Include("Department")
                                            .Select(p => new EmpleadoDTO()
                                            {
                                                DocumentoIdentidad = p.Employee.NationalIDNumber,
                                                Puesto = p.Employee.JobTitle,
                                                FechaNacimiento = p.Employee.BirthDate.ToString(),
                                                EstadoCivil = p.Employee.MaritalStatus.Equals("s", StringComparison.CurrentCultureIgnoreCase) ? "Soltero" : "Casado",
                                                Genero = p.Employee.Gender.Equals("f", StringComparison.CurrentCultureIgnoreCase) ? "Femenino" : "Masculino",
                                                Departmento = p.Department.Name,
                                                SubArea = p.Department.GroupName
                                            })
                                            .ToList();

            foreach (var empleado in ListaEmpleadosProjection)
            {

                Console.WriteLine("Los datos del empleado son: ");
                Console.WriteLine("Nro. Documento del empleado : " + empleado.DocumentoIdentidad);
                Console.WriteLine("Puesto : " + empleado.Puesto);
                Console.WriteLine("Fecha Nacimiento : " + empleado.FechaNacimiento);
                Console.WriteLine("Estado Civil : " + empleado.EstadoCivil);
                Console.WriteLine("Género : " + empleado.Genero);
                Console.WriteLine("Departmento : " + empleado.Departmento);
                Console.WriteLine("SubArea : " + empleado.SubArea);

                Console.WriteLine("Pulse una tecla para continuar");
                Console.ReadKey();
            }

        }
    }
}
