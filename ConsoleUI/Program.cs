using Business.Concrete;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //User user = new User() { Id = 2, Email = "samet2@gamze.com", FirstName = "Samet", LastName = "Gamze"};
            //var result = userManager.GetClaims(user);
            //foreach (var claim in result.Data)
            //{
            //    Console.WriteLine(claim.OperationClaimName);
            //}
            //Console.WriteLine("--------");
        }
    }
}
