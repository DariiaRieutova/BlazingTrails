using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazingTrails.Shared.Features.ManageTrails.TrailDto;

namespace BlazingTrails.Shared.Features.ManageTrails.AddTrail
{
    public record GetTrailRequest(int TrailId) : IRequest<GetTrailRequest.Response>
    {
        public const string RouteTemplate = "api/trails/{trailId}";

        public record Response(Trail Trail);

        public record Trail(int Id, string Name, string Location, string? Image, int TimeInMinutes, int Length, string Description, IEnumerable<RouteInstruction> RouteInstruction);

        public record RouteInstruction(int Id, int Stage, string Description);
    }
}
