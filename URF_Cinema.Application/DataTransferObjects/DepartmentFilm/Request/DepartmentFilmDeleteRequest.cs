namespace URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request
{
    public class DepartmentFilmDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
