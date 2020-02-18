using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectClinic.Base;

namespace ProjectClinic.Implementation
{

    // This class is implemented only for Alternative dosage.
    // Other options need to implement later.
    public class UsageInfo
    {
        public UsageInfo()
        { }

        public UsageInfo(UsageInfo usage)
        {
            UsageID = usage.UsageID;
            ExpectedStartDt = usage.ExpectedStartDt;
            ActualStartDt = usage.ActualStartDt;
            DeclineHistory = usage.DeclineHistory;

        }

      

        public int UsageID;
        public DateTime ExpectedStartDt;
        public DateTime ActualStartDt;

        public int[] AlternateDosage = new int[2] { 100, 200 };

        public Dictionary<DateTime, int> DeclineHistory= new Dictionary<DateTime, int>();       

        // This method will get last date of entry and if the last date is not yesterday,
        // then the dosage is in alternate order so will continue alternate medicin.
        // if the last date is yesterday, then patient declined, so he need to take the same dosage of yesterday.
        public int getTodaysDosage()
        {
            int Dosage = 0;
            DateTime lastDt=  DeclineHistory.Keys.Last();

            if (lastDt.Equals(DateTime.Now.AddDays(-1)))
            {
                 Dosage = DeclineHistory.Values.Last();
            }
            else 
            {
                Dosage=calculateDosage();

            }
            // check history size.
            limitHistorySize();
            return Dosage;
        }

        // Calculate the dates and get the dosage.
        private int calculateDosage()
        {
            int Dosage=0;
            DateTime lastDt = DeclineHistory.Keys.Last();
            int daysDiff = ((TimeSpan)(lastDt - DateTime.Now)).Days;

            if (daysDiff % 2 == 0)
            {
                // find the other from array.

                Dosage = DeclineHistory.Values.Last();

                int[] all = AlternateDosage.Where(x => (x != Dosage)).ToArray();
                Dosage = all[0];
            }
            else 
            {
                Dosage = DeclineHistory.Values.Last();
            }

            return Dosage;
        }

        // To limit the Declined history to 5.
        // Check the dictionary size and remove if greater than 5.
        private void limitHistorySize()
        {
            
            if ((DeclineHistory.Count!=0) & (DeclineHistory.Count == 6))
            {
                DeclineHistory.Remove(DeclineHistory.Keys.Min());
            }            
        }

    }
}
