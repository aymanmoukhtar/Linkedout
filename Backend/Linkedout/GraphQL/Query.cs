using Linkedout.Presentation.Api.GraphQL.Queries;

namespace Linkedout.Presentation.Api.GraphQL
{
    public class Query
    {
        private readonly UserQueries _userQueries;
        private readonly PostQueries _postQueries;
        private readonly ConnectionQueries _connectionQueries;
        public Query(
            UserQueries userQueries,
            PostQueries postQueries,
            ConnectionQueries connectionQueries)
        {
            _userQueries = userQueries;
            _postQueries = postQueries;
            _connectionQueries = connectionQueries;
        }
        public UserQueries User() => _userQueries;
        public PostQueries Post() => _postQueries;
        public ConnectionQueries Connection() => _connectionQueries;
    }
}
