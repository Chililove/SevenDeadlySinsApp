using SDS.Core.Application_Service;
using SDS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace SDS.UI
{
    public class Printer : IPrinter
    {
        private readonly IAvatarService _avatarService;

        public Printer(IAvatarService avatarService)
        {
            _avatarService = avatarService;
        }

        public int ShowMenu(string[] menuItems)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}:{menuItems[i]}");
            }
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > menuItems.Length)
            {
                Console.WriteLine("You must select a menuitem between 1-"+ menuItems.Length +", Sinner!");
            }
            Console.Clear();
            return selection;
        }
    
    public void StartUI()
        {
            string[] menuItems =
               {
                    "Create your avatar",
                    "Show avatars",
                    "Update avatar",
                    "Delete avatar",
                    "Sort and show by price",
                    "Get 5 cheapest avatars",
                    "Exit SDS character setup"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        CreateAvatar();
                        break; 
                    case 2:
                        ListAvatars();
                        break;

                    case 3:
                        UpdateAvatar();
                        break;

                    case 4:
                        Delete();
                        break;
                    case 5:
                        ShowByPrice();
                        break;
                    case 6:
                        Show5Cheapest();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Try again sinner");
                Console.ReadLine();
                Console.Clear();

                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("See you soon");
            Console.Clear();
         }

        private void PrintAvatars(List<Avatar> avatars) {
            foreach (var avatar in avatars)
            {
                Console.WriteLine($"Id: {avatar.Id}\n Name: {avatar.Name}\n Type: {avatar.Type}\n Birthdate: {avatar.Birthday}\n Sold date: {avatar.SoldDate}\n Color: {avatar.Color}\n Previous Owner: {avatar.PreviousOwner}\n Price: {avatar.Price.ToString("C", CultureInfo.CurrentCulture)}");
            }
        }

        public void ShowByPrice() {
            Console.WriteLine("Sort by price:");
            var avatars = _avatarService.GetAvatarsSortByPrice();
            PrintAvatars(avatars);
        }

        public void Show5Cheapest()
        {
            Console.WriteLine("Show 5 cheapest Avatars:");
            var avatars = _avatarService.GetAvatars5Cheapest();
            PrintAvatars(avatars);
        }

        void ListAvatars()
        {
            Console.WriteLine("Saved Avatars:");
            var avatars = _avatarService.GetAvatars();
            PrintAvatars(avatars);
        }

        public void CreateAvatar()
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Type: ");
            var type = Console.ReadLine();
            Console.WriteLine("Birthdate: ");
            DateTime newBirthday;
            while (!DateTime.TryParse(Console.ReadLine(), out newBirthday))
            {
                Console.WriteLine("try again");
            }

            Console.WriteLine("SoldDate: ");
            DateTime newSoldDate;
            while (!DateTime.TryParse(Console.ReadLine(), out newSoldDate))
            {
                Console.WriteLine("try again");
            }


            Console.WriteLine("Color: ");
            var color = Console.ReadLine();
            Console.WriteLine("Previous Owner: ");
            var previousOwner = Console.ReadLine();
            Console.WriteLine("Price: ");
            double newPrice;
            while (!double.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("try again");
            }
            _avatarService.Create(new Avatar()
            {

                Name = name,
                Type = type,
                Birthday = newBirthday,
                SoldDate = newSoldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = newPrice


            }
            );
        }

        public Avatar GetAvatarById()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert a number");
            }
            
            return _avatarService.ReadById(id);
        }

        public void UpdateAvatar()
        {
            Console.WriteLine("Insert id of avatar to update: ");

            var avatar = GetAvatarById();
            
            Console.WriteLine("Name: ");
            avatar.Name = Console.ReadLine();
            Console.WriteLine("Type: ");
            avatar.Type = Console.ReadLine();
            Console.WriteLine("Birthdate: ");
            DateTime newBirthday;
            while (!DateTime.TryParse(Console.ReadLine(), out newBirthday))
            {
                Console.WriteLine("try again");
            }
            avatar.Birthday = newBirthday;
            Console.WriteLine("Sold Date: ");
            DateTime newSoldDate;
            while (!DateTime.TryParse(Console.ReadLine(), out newSoldDate))
            {
                Console.WriteLine("try again");
            }
            avatar.SoldDate = newSoldDate;
            Console.WriteLine("Color: ");
            avatar.Color = Console.ReadLine();
            Console.WriteLine("Previous owner: ");
            avatar.PreviousOwner = Console.ReadLine();
            Console.WriteLine("Price: ");
            double newPrice;
            while (!double.TryParse(Console.ReadLine(), out newPrice))
            {
                Console.WriteLine("try again");
            }
            avatar.Price = newPrice;
            try
            {
                _avatarService.Update(avatar);
            }
            catch (InvalidDataException ide) {
                Console.WriteLine(ide.Message);
            }
        }

        public void Delete()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert id of avatar to delete:");
            }
            Avatar avatar = _avatarService.Delete(id);
            Console.WriteLine("Avatar deleted: " + avatar.Name);
        }
   
     }
       
}