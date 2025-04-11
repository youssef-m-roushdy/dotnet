using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL.Types
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(d => d.Id, type: typeof(IdGraphType)).Description("Id property for Employee object");
            Field(d => d.FirstName, type: typeof(StringGraphType)).Description("FirstName property for Employee object");
            Field(d => d.LastName, type: typeof(StringGraphType)).Description("LastName property for Employee object");
            Field(d => d.Email, type: typeof(StringGraphType)).Description("Email property for Employee object");
        }
    }
}