using Linkedout.Presentation.Api.GraphQL.Queries;

namespace Linkedout.Presentation.Api.GraphQL
{
    public class Query
    {
        private readonly UserQueries _userQueries;

        public Query(UserQueries userQueries)
        {
            _userQueries = userQueries;
        }
        public UserQueries User() => _userQueries;
    }
}
