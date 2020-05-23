using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Users
{
  public class Details
  {
    public class Query : IRequest<User>
    {
      public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, User>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _context = context;
        _mapper = mapper;
      }

      public async Task<User> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _context.Users.FindAsync(request.Id);

        if (user == null) throw new RestException(HttpStatusCode.NotFound, new { user = "Not found" });

        return _mapper.Map<AppUser, User>(user);
      }

    }
  }
}