using Linkedout.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Linkedout.Domain.Users.Entities.Connections
{
    public class Connection : IEntity
    {
        public Connection()
        {
            IsRemoved = false;
            IsAccepted = false;
        }
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string ConnectorId { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsAccepted { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ConnectorId")]
        public virtual User Connector { get; set; }
    }
}
