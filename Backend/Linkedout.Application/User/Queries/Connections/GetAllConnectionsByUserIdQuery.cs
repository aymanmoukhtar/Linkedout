using Linkedout.Application.User.ViewModels;
using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Domain.Users.Entities.Connections;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Linkedout.Application.User.Queries.Connections
{
    public class GetAllConnectionsByUserIdQuery : IRequest<List<ConnectionViewModel>>
    {
        public string UserId { get; set; }
    }

    public class GetAllConnectionsByUserIdQueryHandler : IRequestHandler<GetAllConnectionsByUserIdQuery, List<ConnectionViewModel>>
    {
        private readonly Lazy<IReadonlyRepository<Connection>> _connectionReadOnlyRepository;
        public GetAllConnectionsByUserIdQueryHandler(Lazy<IReadonlyRepository<Connection>> connectionReadOnlyRepository)
        {
            _connectionReadOnlyRepository = connectionReadOnlyRepository;
        }
        public async Task<List<ConnectionViewModel>> Handle(GetAllConnectionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _connectionReadOnlyRepository.Value.GetAll().Where(_ => _.UserId == request.UserId)
                .Select(_ => new ConnectionViewModel
                {
                    Connector = new UserViewModel
                    {
                        FirstName = _.Connector.FirstName,
                        Id = _.Connector.Id,
                        ProfilePicture = _.Connector.ProfilePictureUrl,
                        SmallProfilePicture = _.Connector.SmallProfilePictureUrl
                    }
                }).ToListAsync();

        }
    }
}
