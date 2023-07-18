import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs';
import * as routes from '../shared/constants/routes.contants';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]> {

    return this.http.get<Employee[]>(routes.GET_ALL_EMPLOYEES)

  }

  addEmployee(addEmployeeRequest: Employee): Observable<Employee> {

    addEmployeeRequest.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Employee>(routes.GET_ALL_EMPLOYEES, addEmployeeRequest);

  } 

  getEmployee(id: string): Observable<Employee> {

    var employee = this.http.get<Employee>(routes.GET_EMPLOYEE + id)
    return employee;

  }

  updateEmployee(id: string, updateEmployeeRequest: Employee): Observable<Employee> {

   return this.http.put<Employee>(routes.GET_EMPLOYEE + id, updateEmployeeRequest)

  }

  deleteEmployee(id: string): Observable<Employee> {
    return this.http.delete<Employee>(routes.GET_EMPLOYEE + id)
  }
}