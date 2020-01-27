using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.DTO;

namespace DataAccess
{
    public class DBConnector
    {
        private readonly string _dbConnection;
        private readonly SqlConnection _con;

        /// <summary>
        /// Constructor
        /// </summary>
        public DBConnector()
        {
            _dbConnection = ConfigurationManager.ConnectionStrings["DB_MainConnection"].ConnectionString;
            _con = new SqlConnection(_dbConnection);
        }

        /// <summary>
        /// Verify open the connection with the database
        /// </summary>
        private void openConnection()
        {
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
            }
        }

        #region Areas

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pArea"></param>
        /// <returns></returns>
        public Area AddEmployee(Area pArea)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_ADD_AREA"], _con);
                cmd.CommandType = CommandType.StoredProcedure;

                // set up the parameters
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 2000);
                cmd.Parameters.Add("@codeError", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@msjError", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@nombre"].Value = pArea.Nombre;
                cmd.Parameters["@descripcion"].Value = pArea.Descripcion;


                this.openConnection();
                cmd.ExecuteNonQuery();

                pArea.codeError = Convert.ToInt32(cmd.Parameters["@codeError"].Value);
                pArea.msjError = cmd.Parameters["@msjError"].Value.ToString();
            }
            catch (Exception error)
            {
                pArea.codeError = -1;
                pArea.msjError = error.Message;
            }
            return pArea;
        }

        /// <summary>
        /// Delete the Area from the database.
        /// </summary>
        /// <param name="pArea"></param>
        /// <returns></returns>
        public Area DeleteAreas(Area pArea)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_DELETE_AREA"], _con);
                cmd.CommandType = CommandType.StoredProcedure;

                // set up the parameters
                cmd.Parameters.Add("@idArea", SqlDbType.Int);
                cmd.Parameters.Add("@codeError", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@msjError", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@idArea"].Value = pArea.idArea;

                this.openConnection();
                cmd.ExecuteNonQuery();

                pArea.codeError = Convert.ToInt32(cmd.Parameters["@codeError"].Value);
                pArea.msjError = cmd.Parameters["@msjError"].Value.ToString();
            }
            catch (Exception error)
            {
                pArea.codeError = -1;
                pArea.msjError = error.Message;
            }
            return pArea;
        }

        /// <summary>
        /// Update the name or description of some Area.
        /// </summary>
        /// <param name="pArea"></param>
        /// <returns></returns>
        public Area EditAreas(Area pArea)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_EDIT_AREA"], _con);
                cmd.CommandType = CommandType.StoredProcedure;

                // set up the parameters
                cmd.Parameters.Add("@idArea", SqlDbType.Int);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 2000);
                cmd.Parameters.Add("@codeError", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@msjError", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@idArea"].Value = pArea.idArea;
                cmd.Parameters["@nombre"].Value = pArea.Nombre;
                cmd.Parameters["@descripcion"].Value = pArea.Descripcion;


                this.openConnection();
                cmd.ExecuteNonQuery();

                pArea.codeError = Convert.ToInt32(cmd.Parameters["@codeError"].Value);
                pArea.msjError = cmd.Parameters["@msjError"].Value.ToString();
            }
            catch (Exception error)
            {
                pArea.codeError = -1;
                pArea.msjError = error.Message;
            }
            return pArea;
        }

        /// <summary>
        /// Get all areas or a specific area sent through parameter
        /// </summary>
        /// <param name="pArea"></param>
        /// <returns>List of areas or specific area.</returns>
        public List<Area> GetAreas()
        {
            List<Area> lstArea = new List<Area>();
            SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_GET_AREA"], _con);
            cmd.CommandType = CommandType.StoredProcedure;
            this.openConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Area objArea = new Area
                    {
                        idArea = Int32.Parse(reader["idArea"].ToString()),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString()
                    };
                    lstArea.Add(objArea);
                }
            }
            return lstArea;
        }

        #endregion

        #region Employees


        public Employee AddEmployee(Employee pEmployee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_ADD_EMPLOYEE"], _con);
                cmd.CommandType = CommandType.StoredProcedure;

                // set up the parameters
                cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
                cmd.Parameters.Add("@FechaIngreso", SqlDbType.DateTime);
                cmd.Parameters.Add("@IdJefe", SqlDbType.Int);
                cmd.Parameters.Add("@IdArea", SqlDbType.Int);
                cmd.Parameters.Add("@Foto", SqlDbType.VarBinary);
                cmd.Parameters.Add("@codeError", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@msjError", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@NombreCompleto"].Value = pEmployee.nombreCompleto;
                cmd.Parameters["@Cedula"].Value = pEmployee.cedula;
                cmd.Parameters["@Correo"].Value = pEmployee.correo;
                cmd.Parameters["@FechaNacimiento"].Value = pEmployee.fechaNacimiento;
                cmd.Parameters["@FechaIngreso"].Value = pEmployee.fechaIngreso;
                cmd.Parameters["@IdJefe"].Value = pEmployee.idJefe;
                cmd.Parameters["@IdArea"].Value = pEmployee.idArea;
                cmd.Parameters["@Foto"].Value = pEmployee.foto;
                                             
                this.openConnection();
                cmd.ExecuteNonQuery();

                pEmployee.codeError = Convert.ToInt32(cmd.Parameters["@codeError"].Value);
                pEmployee.msjError = cmd.Parameters["@msjError"].Value.ToString();
            }
            catch (Exception error)
            {
                pEmployee.codeError = -1;
                pEmployee.msjError = error.Message;
            }
            return pEmployee;
        }

        public Employee DeleteAreas(Employee pEmployee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_DELETE_EMPLOYEE"], _con);
                cmd.CommandType = CommandType.StoredProcedure;

                // set up the parameters
                cmd.Parameters.Add("@idEmployee", SqlDbType.Int);
                cmd.Parameters.Add("@codeError", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@msjError", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@idEmployee"].Value = pEmployee.idEmpleado;

                this.openConnection();
                cmd.ExecuteNonQuery();

                pEmployee.codeError = Convert.ToInt32(cmd.Parameters["@codeError"].Value);
                pEmployee.msjError = cmd.Parameters["@msjError"].Value.ToString();
            }
            catch (Exception error)
            {
                pEmployee.codeError = -1;
                pEmployee.msjError = error.Message;
            }
            return pEmployee;
        }

        public Employee EditAreas(Employee pEmployee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_EDIT_EMPLOYEE"], _con);
                cmd.CommandType = CommandType.StoredProcedure;

                // set up the parameters
                cmd.Parameters.Add("@idEmployee", SqlDbType.Int);
                cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100);
                cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
                cmd.Parameters.Add("@FechaIngreso", SqlDbType.DateTime);
                cmd.Parameters.Add("@IdJefe", SqlDbType.Int);
                cmd.Parameters.Add("@IdArea", SqlDbType.Int);
                cmd.Parameters.Add("@Foto", SqlDbType.VarBinary);

                cmd.Parameters.Add("@codeError", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@msjError", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@idEmployee"].Value = pEmployee.idEmpleado;
                cmd.Parameters["@NombreCompleto"].Value = pEmployee.nombreCompleto;
                cmd.Parameters["@Cedula"].Value = pEmployee.cedula;
                cmd.Parameters["@Correo"].Value = pEmployee.correo;
                cmd.Parameters["@FechaNacimiento"].Value = pEmployee.fechaNacimiento;
                cmd.Parameters["@FechaIngreso"].Value = pEmployee.fechaIngreso;
                cmd.Parameters["@IdJefe"].Value = pEmployee.idJefe;
                cmd.Parameters["@IdArea"].Value = pEmployee.idArea;
                cmd.Parameters["@Foto"].Value = pEmployee.foto;

                this.openConnection();
                cmd.ExecuteNonQuery();

                pEmployee.codeError = Convert.ToInt32(cmd.Parameters["@codeError"].Value);
                pEmployee.msjError = cmd.Parameters["@msjError"].Value.ToString();
            }
            catch (Exception error)
            {
                pEmployee.codeError = -1;
                pEmployee.msjError = error.Message;
            }
            return pEmployee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> lstEmployee = new List<Employee>();
            SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["SP_GET_EMPLOYEE"], _con);
            cmd.CommandType = CommandType.StoredProcedure;
            this.openConnection();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee objEmployee = new Employee
                    {
                        idEmpleado = Int32.Parse(reader["IdEmpleado"].ToString()),
                        nombreCompleto = reader["NombreCompleto"].ToString(),
                        cedula = reader["Cedula"].ToString(),
                        correo = reader["Correo"].ToString(),
                        fechaNacimiento = DateTime.Parse((!string.IsNullOrEmpty(reader["FechaNacimiento"].ToString())) ? reader["FechaNacimiento"].ToString() : null),
                        fechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString()),
                        idJefe = Int32.Parse((!string.IsNullOrEmpty(reader["IdJefe"].ToString())) ? reader["IdJefe"].ToString() : "0"),
                        nombreJefe = reader["NombreJefe"].ToString(),
                        idArea = Int32.Parse(reader["IdArea"].ToString()),
                        nombreArea = reader["NombreArea"].ToString()
                        //foto = (byte[])reader["Foto"]
                    };
                    lstEmployee.Add(objEmployee);
                }
            }
            return lstEmployee;
        }
        #endregion

    }
}
