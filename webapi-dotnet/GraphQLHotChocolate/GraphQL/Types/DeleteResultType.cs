using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLHotChocolate.Models;

namespace GraphQLHotChocolate.GraphQL.Types
{
    public class DeleteResultType
    {
        public bool Success { get; set; }
        public Student DeletedStudent { get; set; }
    }
}