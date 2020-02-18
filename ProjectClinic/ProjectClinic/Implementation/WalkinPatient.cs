using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectClinic.Base;

namespace ProjectClinic.Implementation
{
    public class WalkinPatient : IPatient
    {
        public WalkinPatient()
        { }
            // Just initializing with dummy data to test.
            // later data must be taken from db.
            public WalkinPatient(int id, string name, int age)
        {
            PatientID = id;
            PatientName = name;
            PatientAge = age;

            usageInfo.UsageID = 1;
            usageInfo.ExpectedStartDt = DateTime.Now.AddDays(-5);
            usageInfo.ExpectedStartDt = DateTime.Now.AddDays(-4);

            usageInfo.DeclineHistory.Add(DateTime.Now.AddDays(-3), 100);
            usageInfo.DeclineHistory.Add(DateTime.Now.AddDays(-2), 200);
        }

        public int _patientID;
        public string _patientName;
        public int _patientAge;
        public string _patientType;

        public UsageInfo usageInfo;

        public int PatientID { get { return _patientID; } set { _patientID = value; } }
        public string PatientName { get { return _patientName; } set { _patientName = value; } }
        public int PatientAge { get { return _patientAge; } set { _patientAge = value; } }
        public string PatientType { get { return _patientType; } set { _patientType = "WalkinPatient"; } }
        public int DoctorID { get { return _patientID; } set { _patientID = 201; } }

        //public UsageInfo usageInfo { get; set; }

        public void DisplayPatientDetails()
        {
            // int todaysDosage = usageInfo.getTodaysDosage();

            Console.Out.WriteLine("Patient Name : " + PatientName);
            Console.Out.WriteLine("Paient Age : " + PatientAge);
            Console.Out.WriteLine("Patient Type : " + PatientType);
            foreach (var usInfo in usageInfo.DeclineHistory)
            {
                Console.Out.WriteLine("Declined on : " + usInfo.Key.ToString() + ", " + usInfo.Value.ToString());
            }

            Console.ReadLine();
        }

        public void sendPatientAlert(int patientID)
        {



        }

        public void sendPatientAlert()
        {
            throw new NotImplementedException();
        }
    }
}
