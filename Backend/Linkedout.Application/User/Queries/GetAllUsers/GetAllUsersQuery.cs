using Linkedout.Domain.Interfaces.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Linkedout.Application.User.Queries.GetAllUsersQuery
{
    using Linkedout.Domain.Users.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    #region Output
    public class GetAllUsersOutput
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
    #endregion

    #region Query
    public class GetAllUsersQuery : IRequest<List<GetAllUsersOutput>>
    {
    }
    #endregion

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersOutput>>
    {

        private readonly Lazy<IReadonlyRepository<User>> _userReadonlyRepository;

        public GetAllUsersQueryHandler(
           Lazy<IReadonlyRepository<User>> userReadonlyRepository
           )
        {
            _userReadonlyRepository = userReadonlyRepository;
        }

        public async Task<List<GetAllUsersOutput>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userReadonlyRepository.Value
                .GetAll()
                .Select(_ => new GetAllUsersOutput
                {
                    Id = _.Id,
                    FirstName = _.FirstName
                })
                .ToListAsync();
        }
    }
}
