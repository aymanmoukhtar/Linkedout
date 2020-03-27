using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Linkedout.Application.User;
using Linkedout.Application.User.Queries.GetAllUsersQuery;
using Linkedout.Presentation.Api.GraphQL.Nodes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linkedout.Presentation.Api.GraphQL.Queries
{
    public partial class UserQueries
    {
        private readonly Lazy<IMediator> _mediator;

        public UserQueries(
            Lazy<IMediator> mediator
            )
        {
            _mediator = mediator;
        }

        [Authorize]
        public async Task<List<UserViewModel>> GetAll() => await _mediator.Value.Send(new GetAllUsersQuery());

        [Authorize]
        public async Task<UserViewModel> GetById(string id) => await _mediator.Value.Send(new GetUserByIdQuery { Id = id });
    }

    public class UserQueriesType : ObjectType<UserQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<UserQueries> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(_ => _.GetAll())
                .UsePaging<UserViewModelType>();
        }
    }
}
