using SDS.Core.Domain_Service;
using SDS.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;


namespace SDS.Core.Application_Service.Service
{
    public class AvatarService : IAvatarService
    {
        private readonly IAvatarRepository _aRepo;
        public static IEnumerable<Avatar> avatarList;

        public AvatarService(IAvatarRepository aRepo)
        {

            _aRepo = aRepo;
        }

        public Avatar AvatarCreate(string type, string name, DateTime birthday, DateTime soldDate, string color, string previousOwner, double price) 
        {
            var avatar = new Avatar()
            {
                Name = name,
                Type = type,
                Birthday = birthday,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return avatar;
        }

        public Avatar Create(Avatar avatar)
        {
            if (avatar.Name.Length < 1)
            {
                throw new InvalidDataException("You need to put in atleast 1 letter!");
            }
            return _aRepo.Create(avatar);
        }

        public Avatar Update(Avatar avatar)
        {
            if (avatar.Name.Length < 1)
            {
                throw new InvalidDataException("Name must be atleast 1 char");
            }

            if (avatar == null) 
            {
                throw new InvalidDataException("Did not find avatar with id: " + avatar.Id);
            }
            return _aRepo.Update(avatar);
        }

        public List<Avatar> GetAvatars()
        {
            return _aRepo.GetAllAvatars();
        }
        public List<Avatar> GetAvatarsSortByPrice()
        {
            List<Avatar> avatars = GetAvatars();
            List<Avatar> avatarsToSort = new List<Avatar>(); 

            foreach(Avatar a in avatars) {
                avatarsToSort.Add(a);
            }
            avatarsToSort.Sort((avatar1, avatar2) => avatar1.Price.CompareTo(avatar2.Price)); 
            
            return avatarsToSort;
        }

        public List<Avatar> GetAvatars5Cheapest()
        {
            List<Avatar> avatars = GetAvatarsSortByPrice();
            List<Avatar> avatars5cheapest = new List<Avatar>();
            if (avatars.Count >= 5)
            {
                for (int i = 0; i < 5; i++) 
                    avatars5cheapest.Add(avatars[i]);
                return avatars5cheapest;
            }
            return avatars;
        }
        public Avatar Delete(int id)
        {
            if (id < 1)
            {

                throw new InvalidDataException("Id must be atleast 1");
            }
            return _aRepo.Delete(id);
        }

        public Avatar AvatarUpdate(Avatar avatarUpdate) 
        {
            var DBAvatar = ReadById(avatarUpdate.Id);
            if (DBAvatar != null)
            {
                DBAvatar.Name = avatarUpdate.Name;
                DBAvatar.Type = avatarUpdate.Type;
                DBAvatar.Birthday = avatarUpdate.Birthday;
                DBAvatar.SoldDate = avatarUpdate.SoldDate;
                DBAvatar.PreviousOwner = avatarUpdate.PreviousOwner;
                DBAvatar.Price = avatarUpdate.Price;          
            }
            return DBAvatar;           
        }
        
        public Avatar ReadById(int id)
        {
            return _aRepo.GetAvatarById(id);
        }
    }
}