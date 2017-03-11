using System;
using System.Linq;

namespace Projection_EF
{
    public class LoadDataEmployees
    {
        static void Main(string[] args)
        {
            LoadDataEmployes();
        }


        static void LoadDataEmployes()
        {
            var AWEntitiesContext = new AdventureWorks2014Entities();

            var ListaEmpleados = AWEntitiesContext.EmployeeDepartmentHistories
                                    .Include("Employee")
                                    .Include("Department")
                                    .ToList();

            foreach (var empleado in ListaEmpleados)
            {

                Console.WriteLine("Los datos del empleado son: ");
                Console.WriteLine("Nro. Documento del empleado : " + empleado.Employee.NationalIDNumber);
                Console.WriteLine("Puesto : " + empleado.Employee.JobTitle);
                Console.WriteLine("Fecha Nacimiento : " + empleado.Employee.BirthDate.ToString());
                Console.WriteLine("Estado Civil : " + (empleado.Employee.MaritalStatus.Equals("s", StringComparison.CurrentCultureIgnoreCase) ? "Soltero" : "Casado"));
                Console.WriteLine("Genero : " + (empleado.Employee.Gender.Equals("f", StringComparison.CurrentCultureIgnoreCase) ? "Femenino" : "Masculino"));
                Console.WriteLine("Departmento : " + empleado.Department.Name);
                Console.WriteLine("SubArea : " + empleado.Department.GroupName);

                Console.WriteLine("Pulse una tecla para continuar");
                Console.ReadKey();
            }

        }
    }
}
