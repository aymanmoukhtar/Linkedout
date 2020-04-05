using Linkedout.Presentation.Api.GraphQL.Mutations;

namespace Linkedout.Presentation.Api.GraphQL
{
    public class Mutation
    {
        private readonly UserMutations _userMutations;

        public Mutation(UserMutations userMutations)
        {
            _userMutations = userMutations;
        }
        public UserMutations User() => _userMutations;
    }
}
