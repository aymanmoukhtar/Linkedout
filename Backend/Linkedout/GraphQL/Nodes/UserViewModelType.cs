using HotChocolate;
using HotChocolate.Types;
using Linkedout.Application.User;
using Linkedout.Presentation.Api.GraphQL.Queries;

namespace Linkedout.Presentation.Api.GraphQL.Nodes
{
    public class UserViewModelType : ObjectType<UserViewModel>
    {
        protected override void Configure(IObjectTypeDescriptor<UserViewModel> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .AsNode()
                .IdField(_ => _.Id)
                .NodeResolver((ctx, id) => ctx.Service<UserQueries>().GetById(id));
        }
    }

}
