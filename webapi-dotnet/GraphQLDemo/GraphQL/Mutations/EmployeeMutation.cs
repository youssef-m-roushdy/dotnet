using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLDemo.DTOs;
using GraphQLDemo.GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL.Mutations
{
    public class EmployeeMutation : ObjectGraphType
    {
        public EmployeeMutation(IEmployeeRepository repository)
        {
            Field<EmployeeType>(
                "addEmployee",
                "Is used to add new employee to the database",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee", Description = "Employee input parameter" }
                    ),
                resolve: context =>
                {
                    var employee = context.GetArgument<CreateEmployeeDto>("employee");
                    if(employee != null)
                    {
                        return repository.Create(employee);
                    }
                    return null;
                }
            );

            Field<EmployeeType>(
                "updateEmployee",
                "Is used to update existing employee to the database",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Employee id to update" },
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee", Description = "Employee input parameter" }
                    ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var employee = context.GetArgument<UpdateEmployeeDto>("employee");
                    if(employee != null)
                    {
                        return repository.Update(id ,employee);
                    }
                    return null;
                }
            );

            FieldAsync<EmployeeType>(
                "deleteEmployee",
                "Is used to delete existing employee to the database",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Employee id to delete" }
                    ),
                resolve:async context =>
                {
                    var id = context.GetArgument<int>("id");
                    await repository.Delete(id);
                    return true;
                }
            );
        }
    }
}