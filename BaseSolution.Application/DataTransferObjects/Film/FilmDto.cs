using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Film
{
    public class FilmDto
    {
        public Guid Id { get; set; }
        public Guid SneakShowId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime PremiereDate { get; set; }
        public string FilmTime { get; set; }
        public string Type { get; set; }

        public string Image { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
