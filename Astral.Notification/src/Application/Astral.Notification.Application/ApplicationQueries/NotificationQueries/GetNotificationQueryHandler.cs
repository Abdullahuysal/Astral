using Astral.Notification.Core.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Notification.Application.ApplicationQueries.NotificationQueries
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, GetNotificationQueryResponse>
    {
        public Task<GetNotificationQueryResponse> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();

        }
    }
}
