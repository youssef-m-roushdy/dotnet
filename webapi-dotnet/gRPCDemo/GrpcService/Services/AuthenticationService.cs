using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Protos;
using Microsoft.IdentityModel.Tokens;

namespace GrpcService.Services
{
    public class AuthenticationService : AuthProtoService.AuthProtoServiceBase
    {
        public override async Task<CreateIdentityResponse> GenerateToken(Empty request, ServerCallContext context)
        {
            var exp = DateTime.UtcNow.AddHours(1);
            Claim[] claims = [new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString())];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dsad87yfd53zxa8t6thf56fg5fd68ft787u53v1h2cv3xarttyiujn3156dsfvcjg"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: claims,
                expires: exp,
                signingCredentials: creds
            );

            string _token = new JwtSecurityTokenHandler().WriteToken(token);
            await Task.Delay(100);
            return new CreateIdentityResponse{Token = _token};
        }
    }
}