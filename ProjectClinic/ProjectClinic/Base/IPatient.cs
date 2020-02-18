using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClinic.Base
{
    interface IPatient
    {
         int PatientID { get; set; }
         string PatientName { get; set; }
        int PatientAge { get; set; }
        string PatientType { get; set; }
        int DoctorID { get; set; }
       // UsageInfo usageInfo { get; set; }



        void DisplayPatientDetails();
        void sendPatientAlert();

    }
}
