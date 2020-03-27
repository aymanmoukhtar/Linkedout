using Linkedout.Domain.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Linkedout.Application.User.Queries.Login
{
    using Linkedout.Domain.Users.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using static Linkedout.Application.User.Queries.Login.GetAllUsersOutput;

    #region Output
    public class GetAllUsersOutput
    {
        public List<GetAllUsersUserViewModel> Users { get; set; }
        public class GetAllUsersUserViewModel
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
        }
    }
    #endregion

    #region Query
    public class GetAllUsersQuery : IRequest<GetAllUsersOutput>
    {
    }
    #endregion

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersOutput>
    {

        private readonly Lazy<IReadonlyRepository<User>> _userReadonlyRepository;

        public GetAllUsersQueryHandler(
           Lazy<IReadonlyRepository<User>> userReadonlyRepository
           )
        {
            _userReadonlyRepository = userReadonlyRepository;
        }

        public async Task<GetAllUsersOutput> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return new GetAllUsersOutput
            {
                Users = await _userReadonlyRepository.Value
                .GetAll()
                .Select(_ => new GetAllUsersUserViewModel
                {
                    Id = _.Id,
                    FirstName = _.FirstName
                })
                .ToListAsync()
            };
        }
    }
}
