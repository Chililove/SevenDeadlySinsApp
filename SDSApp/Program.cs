using Microsoft.Extensions.DependencyInjection;
using SDS.Core.Application_Service;
using SDS.Core.Application_Service.Service;
using SDS.Core.Domain_Service;
using SDS.Core.Entity;
using SDS.Infrastructure.Data;
using SDS.Infrastructure.Data.Repositories;
using SDS.UI;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace SDSApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            
            IAvatarRepository aRepo = new AvatarRepo();
            DBInit db = new DBInit(aRepo);
            db.InitData(); // Mock data
            IAvatarService aService = new AvatarService(aRepo);
            IPrinter print = new Printer(aService);
            Console.WriteLine("Hello fellow Seven Deadly Sins maniac!");

            Console.WriteLine("Welcome to SDS\nBegin your adventure by choosing an option in the menu");
            print.StartUI();
        }

    }


    
}
