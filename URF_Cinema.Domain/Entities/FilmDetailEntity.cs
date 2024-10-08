﻿using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Domain.Entities
{
    public class FilmDetailEntity
    {
        public Guid Id { get; set; }
        public Guid FilmId { get; set; }
        public Guid FilmScheduleId { get; set; }
        public virtual FilmEntity Film { get; set; }
        public virtual FilmScheduleEntity FilmSchedule { get; set; }
    }
}
