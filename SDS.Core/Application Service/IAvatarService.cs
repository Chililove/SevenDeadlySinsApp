using System;
using System.Collections.Generic;
using System.Text;
using SDS.Core.Entity;

namespace SDS.Core.Application_Service
{
    public interface IAvatarService
    {

        public List<Avatar> GetAvatars();
        Avatar AvatarCreate(string type, string name, DateTime birthday, DateTime soldDate, string color, string previousOwner, double price);

        Avatar Create(Avatar avatar);

       // List<Avatar> ReadAllAvatars();

        Avatar Update(Avatar avatar);

        Avatar Delete(int id);

        public List<Avatar> GetAvatars5Cheapest();
        public List<Avatar> GetAvatarsSortByPrice();

        Avatar ReadById(int id);
    }
}
