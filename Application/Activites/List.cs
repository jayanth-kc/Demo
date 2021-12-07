using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activites
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _dataContext;
            private  ILogger<List> _logger;
            public Handler(DataContext dataContext, ILogger<List> logger)
            {
                _logger =logger;
                _dataContext = dataContext;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
              /*  try
                {
                    for(int i=1; i<=10;i++)
                    {
                         cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(100, cancellationToken);
                        _logger.LogInformation("Iteration " + i.ToString());
                    }
                   
                }
                catch(Exception ex) when (ex is TaskCanceledException)
                {
                    _logger.LogInformation("Task got cancelled");
                }*/
                return await _dataContext.Activities.ToListAsync();
            }
        }
    }
}
