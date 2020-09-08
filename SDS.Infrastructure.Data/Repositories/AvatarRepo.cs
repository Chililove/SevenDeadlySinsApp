using SDS.Core.Domain_Service;
using SDS.Core.Entity;
using System.Collections.Generic;

namespace SDS.Infrastructure.Data.Repositories
{
    
    public class AvatarRepo : IAvatarRepository

    {
        private static List<Avatar> _avatarList = new List<Avatar>();
        static int id = 1;
        public Avatar Create(Avatar avatar)
        {
            avatar.Id = id++;
            _avatarList.Add(avatar);
            return avatar;
        }

        public Avatar GetAvatarById(int Id)
        {
            foreach (var avatar in _avatarList)
            {
                if (avatar.Id == id)
                {
                    return avatar;
                }
            }
            return null;
        }

        public List<Avatar> GetAllAvatars()
        {
            return _avatarList;               
        }

        public IEnumerable<Avatar> ReadAllAvatars() 
        {
            return _avatarList;
        }

        public Avatar Update(Avatar avatarUpdate)
        {
            var avatarFromDB = this.GetAvatarById(avatarUpdate.Id);
            if (avatarFromDB != null)
            {
                avatarFromDB.Name = avatarUpdate.Name;
                avatarFromDB.Type = avatarUpdate.Type;
                avatarFromDB.Birthday = avatarUpdate.Birthday;
                avatarFromDB.SoldDate = avatarUpdate.SoldDate;
                avatarFromDB.Color = avatarUpdate.Color;
                avatarFromDB.PreviousOwner = avatarUpdate.PreviousOwner;
                avatarFromDB.Price = avatarUpdate.Price;
                return avatarFromDB;
            }
            return null;
        }

        public Avatar Delete(int id)
        {
            var avatarFound = this.GetAvatarById(id);
            if (avatarFound != null)
            {
                _avatarList.Remove(avatarFound);
                return avatarFound;
            }
            return null;
        }
    }
}
