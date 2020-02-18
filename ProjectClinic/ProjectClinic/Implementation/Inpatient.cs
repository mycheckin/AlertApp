using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectClinic.Base;

namespace ProjectClinic.Implementation
{
    public class Inpatient:IPatient
    {
        public Inpatient()
        { 
        }
        // Just initializing with dummy data to test.
        // later data must be taken from db.
        public Inpatient(Inpatient objPatient)
        {

            PatientID = objPatient.PatientID;
            PatientName = objPatient.PatientName;
            PatientAge = objPatient.PatientAge;

            usageInfo.UsageID = objPatient.usageInfo.UsageID;
            usageInfo.ExpectedStartDt = objPatient.usageInfo.ExpectedStartDt;
            usageInfo.ActualStartDt = objPatient.usageInfo.ActualStartDt;

            usageInfo.DeclineHistory = objPatient.usageInfo.DeclineHistory;            
        }
        


        private int _patientID;
        private string _patientName;
        private int _patientAge;
        private string _patientType="InPatient";

        public UsageInfo usageInfo = new UsageInfo();

        public int PatientID { get { return _patientID; } set { _patientID = value; } }
        public string PatientName { get { return _patientName; } set { _patientName = value; } }
        public int PatientAge { get { return _patientAge; } set { _patientAge = value; } }
        public string PatientType { get { return _patientType; } set { _patientType = "InPatient"; } }

        public int DoctorID { get { return _patientID; } set { _patientID = 101; } }

       // public UsageInfo usageInfo { get; set; }

        public void DisplayPatientDetails()
        {
            // int todaysDosage = usageInfo.getTodaysDosage();

            Console.Out.WriteLine("Patient Name : " + PatientName);
            Console.Out.WriteLine("Paient Age : " + PatientAge);
            Console.Out.WriteLine("Patient Type : " + this.PatientType);

            foreach (var usInfo in usageInfo.DeclineHistory)
            {
                Console.Out.WriteLine("Declined on : " + usInfo.Key.ToString() + ", " + usInfo.Value.ToString());
            }

            Console.ReadLine();
        }

        public void sendPatientAlert()
        {
            UsageInfo usage = new UsageInfo(usageInfo);

            Console.WriteLine("Todays dosage : " + usage.getTodaysDosage());
            Console.WriteLine("Patient Accept/Declained : " + "Y/N");
            // Get patient respondse.
            string T = Console.ReadLine();

            if ((T).ToUpper().Equals(("Y")))
            {
                Console.WriteLine("Patient accepted.");
            }
            else 
            {
                // If declained update DB.
                Console.WriteLine("Patient declined.");
                usageInfo.DeclineHistory.Add(DateTime.Now, usage.getTodaysDosage());
            }
            Console.ReadLine();

        }

       
    }
}
