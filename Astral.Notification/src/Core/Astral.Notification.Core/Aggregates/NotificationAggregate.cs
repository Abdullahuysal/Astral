using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral.Notification.Core.Aggregates
{
    public class NotificationAggregate
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; private set; }
        public DateTime UpdateTime { get; private set; }
        public int Type { get; private set; }
        public int TemplateId { get; private set; }
        public long SenderId { get; private set; }
        public long ReceiverId { get; private set; }
        public short Status { get; private set; }




        public NotificationAggregate()
        {

        }

        public NotificationAggregate CreateNotification(int type, int templateId, long senderId, long receiverId, short status)
        {
            return new NotificationAggregate
            {
                Id = Guid.NewGuid(),
                CreateTime = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow,
                Type = type,
                TemplateId = templateId,
                SenderId = senderId,
                ReceiverId = receiverId,
                Status = status,//todo Enum
            };
        }

    }
}
