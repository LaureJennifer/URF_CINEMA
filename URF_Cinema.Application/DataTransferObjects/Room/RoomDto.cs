﻿using URF_Cinema.Domain.Enums;

namespace URF_Cinema.Application.DataTransferObjects.Room
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }

        public Guid RoomLayoutId { get; set; }
        public string RoomLayoutName { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAddress { get; set; }
        public int Capacity { get; set; } //Sức chứa
        public string Code { get; set; }
        public string SoundSystem { get; set; }
        public string ScreenSize { get; set; }       
        public EntityStatus Status { get; set; }
    }
}
