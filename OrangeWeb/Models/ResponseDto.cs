﻿namespace OrangeWeb.Mode
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } 
        public object? Result { get; set; }
        public string Message { get; set; } = "";
    }
}
