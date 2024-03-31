﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Room.Request
{
    public class RoomDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
