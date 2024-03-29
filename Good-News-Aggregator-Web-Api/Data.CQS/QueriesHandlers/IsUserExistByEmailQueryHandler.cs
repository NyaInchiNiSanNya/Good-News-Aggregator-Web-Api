﻿using Data.CQS.Queries;
using Entities_Context.Entities.UserNews;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Data.CQS.QueriesHandlers
{
    public class IsUserExistByEmailQueryHandler:IRequestHandler<IsUserExistByEmailQuery,Boolean>
    {
        private readonly UserArticleContext _articleContext;

        public IsUserExistByEmailQueryHandler(UserArticleContext articleContext)
        {
            _articleContext = articleContext ?? throw new NullReferenceException(nameof(articleContext));
        }

        public async Task<Boolean> Handle(IsUserExistByEmailQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.Email))
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await _articleContext.Users.
                Where(x => x.Email.Equals(request.Email))
                .AnyAsync(cancellationToken: cancellationToken);
        }
    }
}
