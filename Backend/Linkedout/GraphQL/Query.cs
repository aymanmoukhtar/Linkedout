using Linkedout.Presentation.Api.GraphQL.Queries;

namespace Linkedout.Presentation.Api.GraphQL
{
    public class Query
    {
        private readonly UserQueries _userQueries;
        private readonly PostQueries _postQueries;
        public Query(UserQueries userQueries, PostQueries postQueries)
        {
            _userQueries = userQueries;
            _postQueries = postQueries;
        }
        public UserQueries User() => _userQueries;
        public PostQueries Post() => _postQueries;
    }
}
