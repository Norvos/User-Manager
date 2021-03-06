using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;
using System.IO;


namespace Application.Users
{

  public class Photo
  {
    public class Command : IRequest<string>
    {
      public int Id { get; set; }
      public IFormFile File { get; set; }
    }

    public class Handler : IRequestHandler<Command, string>
    {
      public async Task<string> Handle(Command request, CancellationToken cancellationToken)
      {
        if (request.File == null || request.File.Length == 0)
          throw new RestException(HttpStatusCode.NotFound, new { file = "Not found" });

    
        var folderName = Path.Combine("resources", "images");
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        if (!Directory.Exists(filePath))
        {
          Directory.CreateDirectory(filePath);
        }

        var uniqueFileName = $"{request.Id}.png";
        var dbPath = Path.Combine(folderName, uniqueFileName);

        using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
        {
          await request.File.CopyToAsync(fileStream);
        }

        dbPath = Path.Combine("http://localhost:5000", dbPath).Replace("\\","/");
  
        return dbPath;
      }
    }

  }
}