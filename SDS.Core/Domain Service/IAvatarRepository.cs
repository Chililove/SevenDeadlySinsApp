using SDS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Core.Domain_Service
{
    public interface IAvatarRepository
    {
        IEnumerable<Avatar> ReadAllAvatars();
        public List<Avatar> GetAllAvatars();

        Avatar Create(Avatar avatar);

        Avatar GetAvatarById(int Id);

        Avatar Update(Avatar avatarUpdate);

       Avatar Delete(int Id);
       // Avatar Delete(Avatar avatar);
    }
}
