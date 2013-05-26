﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataAccess.Repositories.Interfaces;
using AdventureWorks.Model.HumanResources;
using System.Data.Entity;
using AdventureWorks.Service.ViewModel;

namespace AdventureWorks.Service
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            var employees = from e in _repository.GetEmployees()
                            select new EmployeeViewModel
                                {
                                    EmployeeId = e.EmployeeId,
                                    LoginId = e.LoginId,
                                    NationalIdNumber = e.NationalIdNumber,
                                    Name = e.Contact.FullName,
                                    Email = e.Contact.EmailAddress,
                                    Phone = e.Contact.Phone,
                                    Title = e.Title,
                                    ManagerId = e.ManagerId ?? 0,
                                    ManagerName = e.Manager.Contact.FullName,
                                    BirthDate = e.BirthDate.ToString("yyyy-MM-dd"),
                                    MaritalStatus = e.MaritalStatus == "M" ? "已婚" : "未婚",
                                    Gender = e.Gender == "M" ? "男" : "女",
                                    HireDate = e.HireDate.ToString("yyyy-MM-dd")
                                };

            return employees.AsEnumerable();
        }
    }
}