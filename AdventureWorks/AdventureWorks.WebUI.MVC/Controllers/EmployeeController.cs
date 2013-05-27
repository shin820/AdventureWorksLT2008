﻿using System.Collections.Generic;
using System.Web.Mvc;
using AdventureWorks.Service;
using AdventureWorks.Service.ViewModel;
using AdventureWorks.WebUI.MVC.Context;
using Microsoft.Practices.Unity;

namespace AdventureWorks.WebUI.MVC.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController()
        {
            _service = ApplicationContext.Current.Container.Resolve<IEmployeeService>();
        }


        public ActionResult Details()
        {
            IEnumerable<EmployeeViewModel> employees = _service.GetEmployees();
            return View(employees);
        }
    }
}