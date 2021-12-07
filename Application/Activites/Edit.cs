using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activites
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity {get;set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;
            private IMapper _mapper;
            public Handler(DataContext dataContext, IMapper mapper)
            {
                _mapper=mapper;
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities.FindAsync(command.Activity.Id);
               // activity.Title= command.Activity.Title ??activity.Title;
               _mapper.Map(command.Activity,activity);

                await _dataContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
