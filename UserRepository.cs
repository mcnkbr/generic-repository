using Dto.Dto;
using Dto.GeneralModel;
using Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Dto.Enums;
 
namespace Repository
{
    public class UserRepository : GenericRepository<Entity.AeeeEntities, Entity.User, UserDto>
    {
        //Add,Edit,Delete,GetAll,FindBy methods created by GenericRepository
        //base.Add(...);
    }
}
