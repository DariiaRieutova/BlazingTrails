using Ardalis.ApiEndpoints;
using BlazingTrails.Shared.Features.Home.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingTrails.Api.Features.Home.Shared
{
    public class GetTrailsEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetTrailsRequest.Response>
    {
        private readonly BlazingTrailsContext _context;

        public GetTrailsEndpoint(BlazingTrailsContext database)
        {
            _context = database;
        }

        [HttpGet(GetTrailsRequest.RouteTemplate)]
        public override async Task<ActionResult<GetTrailsRequest.Response>> HandleAsync(
            int trailId,
            CancellationToken cancellationToken = default)
        {
            var trails = await _context.Trails.Include(x => x.Route).ToListAsync(cancellationToken);

            var response = new GetTrailsRequest.Response(trails.Select(trail => new GetTrailsRequest.Trail(
                trail.Id,
                trail.Name,
                trail.Image,
                trail.Location,
                trail.TimeInMinutes,
                trail.Length,
                trail.Description
            )));

            return Ok(response);
        }
    }
}
