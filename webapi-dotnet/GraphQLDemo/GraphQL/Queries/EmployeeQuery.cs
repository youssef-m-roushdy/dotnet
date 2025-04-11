using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLDemo.GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL.Queries
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            Field<ListGraphType<EmployeeType>>(
                "employees",
                "Return all the employees",
                resolve: context => employeeRepository.GetAll()
            );
            
            Field<EmployeeType>(
                "employee",
                "Return a single employee by Id",
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" , Description = "Employee Id"}),
                resolve: context => employeeRepository.GetById(context.GetArgument("id", int.MinValue))
            );
        }
    }
}