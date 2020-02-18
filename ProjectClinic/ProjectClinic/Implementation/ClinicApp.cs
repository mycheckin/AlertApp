using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectClinic.Base;

namespace ProjectClinic.Implementation
{
   public  class ClinicApp
    {
        public static void Main(string[] args)
       {
            IPatient inPatient = new Inpatient((Inpatient)connectDB());
            inPatient.DisplayPatientDetails();
            inPatient.sendPatientAlert();


         


        }



        // connect to DB and get data.
        public static Inpatient connectDB()
        {
            // Dummy data. will fetch data from DB later.
            Inpatient inPatient = new Inpatient();

            inPatient.PatientID = 100;
            inPatient.PatientAge = 20;
            inPatient.PatientName = "someone";
            //inPatient.PatientType = inPatient.PatientType;
            inPatient.DoctorID = 100;
            
            inPatient.usageInfo.UsageID = 10020;
            inPatient.usageInfo.ExpectedStartDt = DateTime.Now.AddDays(-15);
            inPatient.usageInfo.ActualStartDt = DateTime.Now.AddDays(-10);
            inPatient.usageInfo.DeclineHistory.Add(DateTime.Now.AddDays(-2), 100);
           
            return (Inpatient)inPatient;
        }
    }
}
