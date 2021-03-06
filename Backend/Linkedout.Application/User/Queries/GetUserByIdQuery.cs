﻿using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Application.User.ViewModels;

namespace Linkedout.Application.User.Queries
{
    using Linkedout.Domain.Users.Entities;

    #region Query
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public string Id { get; set; }
    }
    #endregion

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {

        private readonly Lazy<IReadonlyRepository<User>> _userReadonlyRepository;

        public GetUserByIdQueryHandler(
           Lazy<IReadonlyRepository<User>> userReadonlyRepository
           )
        {
            _userReadonlyRepository = userReadonlyRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userReadonlyRepository.Value.GetById(request.Id);

            return new UserViewModel
            {
                Id = user.Id,
                NormalizedId = user.Id,
                FirstName = user.FirstName
            };
        }
    }
}
