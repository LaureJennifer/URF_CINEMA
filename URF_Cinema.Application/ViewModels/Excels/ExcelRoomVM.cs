using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.ViewModels.Excels
{
    public class ExcelRoomVM
    {
        public int Capacity { get; set; } //Sức chứa
        public string Code { get; set; }
        public string SoundSystem { get; set; }
        public string ScreenSize { get; set; }
        public RoomEntity ConvertToEntity()
        {
            return new RoomEntity()
            {
                Code = Code,
                Capacity = Capacity,
                SoundSystem = SoundSystem,
                ScreenSize = ScreenSize
            };
        }
    }
}
