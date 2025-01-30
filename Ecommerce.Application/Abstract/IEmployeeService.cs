﻿using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Abstract;

public interface IEmployeeService
{
    List<Employee> GetAll();
    Employee GetById(int id);
    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
}
