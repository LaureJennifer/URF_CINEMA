using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
    public class FilmEntity : IEntityBase
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string TrailerURL { get; set; }
        public string Description { get; set; }
        public string PosterURL { get; set; }
        public string DirectedBy { get; set; }
        public string Language { get; set; }
        public string Actor { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Duration { get; set; }
        public string Script {  get; set; }
        public string Genres { get; set; }
        
        public string AgeRating { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public List<DepartmentFilmEntity> DepartmentFilms { get; set;}
        public List<FilmDetailEntity> FilmDetails{ get; set;}
        public List<TicketEntity> Tickets { get; set;}
    }
}
