﻿namespace URF_Cinema.Application.DataTransferObjects.Example.Request
{
    public class ExampleUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
