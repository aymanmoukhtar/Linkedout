using Linkedout.Presentation.Api.GraphQL.Mutations;

namespace Linkedout.Presentation.Api.GraphQL
{
    public class Mutation
    {
        private readonly UserMutations _userMutations;
        private readonly PostMutations _postMutations;

        public Mutation(UserMutations userMutations, PostMutations postMutations)
        {
            _userMutations = userMutations;
            _postMutations = postMutations;
        }
        public UserMutations User() => _userMutations;
        public PostMutations Post() => _postMutations;
    }
}
