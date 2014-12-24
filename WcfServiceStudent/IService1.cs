using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceStudent
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "WcfServiceStudent")]
    public interface IService1
    {

        [OperationContract(Action = "StudentService/GetStudents")]
        List<Student> getStudents();

        [OperationContract]
        string GetData(int value);

        [OperationContract(Action = "StudentService/GetStudentById")]
        Student getStudentById(int studentID);

        [OperationContract(Action = "StudentService/deleteStudent")]
        void deleteStudent(int studentID);

        [OperationContract(Action = "StudentService/AddStudent")]
        void addStudent(String studentName,String IndexNumber, String City, String address, String jmbg, String sex, DateTime datumRodj );

        [OperationContract(Action = "StudentService/updateStudent")]
        void updateStudent(Int32 studentID, String studentName, String IndexNumber, String City, String address, String jmbg, String sex, DateTime datumRodj);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    [DataContract(Namespace = "WcfServiceStudent")]
    public class Student
    {
        public Int32 studentId;
        public String studentName;
        public String indexNumber;
        public String city;
        public String address;
        public String JMBG;
        public String sex;
        public DateTime birthDate;

        [DataMember]
        public Int32 StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        [DataMember]
        public String StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        [DataMember]
        public String IndexNumber
        {
            get { return indexNumber; }
            set { indexNumber = value; }
        }

        [DataMember]
        public String City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public String Jmbg
        {
            get { return JMBG; }
            set { JMBG = value; }
        }

        [DataMember]
        public String Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        [DataMember]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
