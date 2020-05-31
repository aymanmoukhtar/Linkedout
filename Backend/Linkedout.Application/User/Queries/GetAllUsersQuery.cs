using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Linkedout.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Linkedout.Application.User.ViewModels;

namespace Linkedout.Application.User.Queries
{
    using Linkedout.Domain.Users.Entities;


    #region Query
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
    }
    #endregion

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {

        private readonly Lazy<IReadonlyRepository<User>> _userReadonlyRepository;

        public GetAllUsersQueryHandler(
           Lazy<IReadonlyRepository<User>> userReadonlyRepository
           )
        {
            _userReadonlyRepository = userReadonlyRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userReadonlyRepository.Value
                .GetAll()
                .Select(_ => new UserViewModel
                {
                    Id = _.Id,
                    FirstName = _.FirstName,
                    NormalizedId = _.Id
                })
                .ToListAsync();
        }
    }
}
