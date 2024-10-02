using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.ViewModels.Excels
{
    public class ExcelRoomLayoutVM
    {
        public string Name {  get; set; }
        public RoomLayoutEntity ConvertToEntity()
        {
            return new RoomLayoutEntity()
            {
                Name = Name,
            };
        }
    }
}
