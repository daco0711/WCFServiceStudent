using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceStudent
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Student> getStudents()
        {
            SqlConnection connection = new SqlConnection();
            DataSet dataset = new DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("Select * from tbl_Student");
            connection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Student;User ID=sa;Password = daco;MultipleActiveResultSets=True");
            query.Connection = connection;
            connection.Open();
            SqlDataReader dataReader = query.ExecuteReader();
            List<Student> students = new List<Student>();

            while (dataReader.Read())
            {
                Student student = new Student();
                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.StudentId = Convert.ToInt32(dataReader["ID"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.StudentName = Convert.ToString(dataReader["StudentName"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.IndexNumber = Convert.ToString(dataReader["IndexNumber"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.City = Convert.ToString(dataReader["City"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.Address = Convert.ToString(dataReader["Address"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.studentId = Convert.ToInt32(dataReader["ID"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.Jmbg = Convert.ToString(dataReader["JMBG"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.Sex = Convert.ToString(dataReader["Sex"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.BirthDate = Convert.ToDateTime(dataReader["BirthDate"]);
                }
                students.Add(student);


            }
            return students;



        }

        public Student getStudentById(int studentID)
        {
            SqlConnection connection = new SqlConnection();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tbl_Student where ID=" + studentID);
            connection.ConnectionString = "Data Source=DACO-PC;Initial Catalog=Student;User ID=sa;Password = daco;MultipleActiveResultSets=True";
            query.Connection = connection;

            connection.Open();
            SqlDataReader dataReader = query.ExecuteReader();

            Student student = new Student();
            while (dataReader.Read())
            {

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.StudentId = Convert.ToInt32(dataReader["ID"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.StudentName = Convert.ToString(dataReader["StudentName"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.IndexNumber = Convert.ToString(dataReader["IndexNumber"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.City = Convert.ToString(dataReader["City"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.Address = Convert.ToString(dataReader["Address"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.studentId = Convert.ToInt32(dataReader["ID"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.Jmbg = Convert.ToString(dataReader["JMBG"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.Sex = Convert.ToString(dataReader["Sex"]);
                }

                if (!Convert.IsDBNull(dataReader["ID"]))
                {
                    student.BirthDate = Convert.ToDateTime(dataReader["BirthDate"]);
                }
            }
            dataReader.Close();
            return student;
        }

        public void deleteStudent(Int32 studentID)
        {

            Student delStud = new Student();
            SqlConnection connection = new SqlConnection();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("delete from tbl_Student where ID=" + studentID);
            connection.ConnectionString = "Data Source=DACO-PC;Initial Catalog=Student;User ID=sa;Password = daco;MultipleActiveResultSets=True";
            query.Connection = connection;
            connection.Open();
            SqlDataReader dataReader = query.ExecuteReader();
            dataReader.Close();
        }

        public void addStudent(String studentName, String IndexNumber, String City, String address, String jmbg, String sex, DateTime datum)
        {
            Student dodStud = new Student();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DACO-PC;Initial Catalog=Student;User ID=sa;Password = daco;MultipleActiveResultSets=True";
            string qString = " Insert into tbl_Student (studentName,IndexNumber,City,Address,JMBG,Sex,BirthDate) values (@studentName,@IndexNUmber,@City,@Address,@JMBG,@Sex,@datum)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = connection;


            cmd.Parameters.Add("@studentName", SqlDbType.VarChar);
            cmd.Parameters["@studentName"].Value = studentName;

            cmd.Parameters.Add("@IndexNumber", SqlDbType.VarChar);
            cmd.Parameters["@IndexNumber"].Value = IndexNumber;

            cmd.Parameters.Add("@City", SqlDbType.VarChar);
            cmd.Parameters["@City"].Value = City;

            cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            cmd.Parameters["@Address"].Value = address;

            cmd.Parameters.Add("@JMBG", SqlDbType.VarChar);
            cmd.Parameters["@JMBG"].Value = jmbg;

            cmd.Parameters.Add("@Sex", SqlDbType.VarChar);
            cmd.Parameters["@Sex"].Value = sex;

            cmd.Parameters.Add("@datum", SqlDbType.DateTime);
            cmd.Parameters["@datum"].Value = datum;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }

        }
        public void updateStudent(Int32 studentID, String studentName, String IndexNumber, String City, String address, String jmbg, String sex, DateTime datumRodj)
        {

            SqlConnection connection = new SqlConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            String qString = ("update tbl_Student set studentName=@studentName,IndexNumber=@IndexNumber,City=@City,Address=@Address,JMBG=@JMBG,Sex=@Sex,BirthDate=@BirthDate where ID=@studentID");
            connection.ConnectionString = "Data Source=DACO-PC;Initial Catalog=Student;User ID=sa;Password = daco;MultipleActiveResultSets=True";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = connection;

            cmd.Parameters.Add("@studentName", SqlDbType.VarChar);
            cmd.Parameters["@studentName"].Value = studentName;

            cmd.Parameters.Add("@IndexNumber", SqlDbType.VarChar);
            cmd.Parameters["@IndexNumber"].Value = IndexNumber;

            cmd.Parameters.Add("@City", SqlDbType.VarChar);
            cmd.Parameters["@City"].Value = City;

            cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            cmd.Parameters["@Address"].Value = address;

            cmd.Parameters.Add("@JMBG", SqlDbType.VarChar);
            cmd.Parameters["@JMBG"].Value = jmbg;

            cmd.Parameters.Add("@Sex", SqlDbType.VarChar);
            cmd.Parameters["@Sex"].Value = sex;

            cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime);
            cmd.Parameters["@BirthDate"].Value = datumRodj;

            cmd.Parameters.Add("@studentID", SqlDbType.Int);
            cmd.Parameters["@studentID"].Value = studentID;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }
        
        }
    }


}


















