using System;
using System.Collections.Generic;

namespace AdventureWorks.Model.HumanResources
{
    public class HumanResources_Shift
    {
        public byte ShiftId { get; set; } // ShiftID (Primary key)
        public string Name { get; set; } // Name
        public DateTime StartTime { get; set; } // StartTime
        public DateTime EndTime { get; set; } // EndTime
        public DateTime ModifiedDate { get; set; } // ModifiedDate

        // Reverse navigation
        public virtual ICollection<HumanResources_EmployeeDepartmentHistory> HumanResources_EmployeeDepartmentHistory { get; set; } // EmployeeDepartmentHistory.FK_EmployeeDepartmentHistory_Shift_ShiftID;

        public HumanResources_Shift()
        {
            ModifiedDate = DateTime.Now;
            HumanResources_EmployeeDepartmentHistory = new List<HumanResources_EmployeeDepartmentHistory>();
        }
    }
}