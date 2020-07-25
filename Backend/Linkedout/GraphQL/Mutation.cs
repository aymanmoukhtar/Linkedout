using Linkedout.Presentation.Api.GraphQL.Mutations;

namespace Linkedout.Presentation.Api.GraphQL
{
    public class Mutation
    {
        private readonly UserMutations _userMutations;
        private readonly PostMutations _postMutations;
        private readonly ConnectionMutations _connectionMutations;
        public Mutation(
            UserMutations userMutations,
            PostMutations postMutations,
            ConnectionMutations connectionMutations)
        {
            _userMutations = userMutations;
            _postMutations = postMutations;
            _connectionMutations = connectionMutations;
        }
        public UserMutations User() => _userMutations;
        public PostMutations Post() => _postMutations;
        public ConnectionMutations Connection() => _connectionMutations;
    }
}
