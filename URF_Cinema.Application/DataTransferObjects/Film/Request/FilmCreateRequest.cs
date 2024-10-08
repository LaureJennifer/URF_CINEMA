﻿using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Film.Request
{
    public class FilmCreateRequest
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string TrailerURL { get; set; }
        public string Description { get; set; }
        public string PosterURL { get; set; }
        public string UrlImage { get; set; }
        public string DirectedBy { get; set; }
        public string Language { get; set; }
        public string Actor { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Duration { get; set; }
        public string Script { get; set; }
        public string Genres { get; set; }

        public string AgeRating { get; set; }
        public EntityStatus Status { get; set; }
    }
}
