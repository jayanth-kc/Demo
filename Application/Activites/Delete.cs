using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activites
{
    public class Delete
    {
        public class Query : IRequest
        {
            public Guid Id {get;set;}
        }

        public class Handler : IRequestHandler<Query>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
               var activity = await  _dataContext.Activities.FindAsync(request.Id);
                 _dataContext.Remove(activity);
                await _dataContext.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
