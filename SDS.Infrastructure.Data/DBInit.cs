using SDS.Core.Domain_Service;
using SDS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SDS.Infrastructure.Data
{
    public class DBInit
    {
        private readonly IAvatarRepository _avatarRepository;
        public DBInit(IAvatarRepository avatarRepository)
        {
            _avatarRepository = avatarRepository;
        }
        public void InitData()
        {
            Random r = new Random();
            _avatarRepository.Create(new Avatar
            {
            Name = "Bradley",
            Type = "Meliodas",
            Birthday = DateTime.Now.Date,
            SoldDate = DateTime.Now.Date,
            Color = "blue",
            PreviousOwner = "Lotte",
            Price = 250
        });
            _avatarRepository.Create(new Avatar
        {
                     Name = "Chili",
                     Type = "Chililove",
                     Birthday = DateTime.Now.AddYears(-1*r.Next(1,100)),
                     SoldDate = DateTime.Now.Date.AddYears(-5),
                     Color = "purple",
                     PreviousOwner = "hans",
                     Price = 400
                 });

            GiantMock.AddToRepo(_avatarRepository);
            foreach (Avatar avatar in _avatarRepository.GetAllAvatars()) {
                int bdInt = r.Next(1, 100);
                avatar.Birthday = DateTime.Now.AddYears(-1 * bdInt);
                avatar.Birthday = avatar.Birthday.AddDays(r.Next(0,365));
                avatar.Birthday = avatar.Birthday.AddSeconds(r.Next(0, 60*60*24));
                avatar.SoldDate = DateTime.Now.AddYears(-1 * r.Next(1, bdInt));
                avatar.SoldDate = avatar.SoldDate.AddDays(r.Next(0, 365));
                avatar.SoldDate = avatar.SoldDate.AddSeconds(r.Next(0, 60 * 60 * 24));
            }

        }

    }
}
