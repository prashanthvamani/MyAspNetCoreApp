﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Models.Response
{
    public class ApiResponseModel<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }
        public string Message { get; set; }

        public ApiResponseModel(bool success,T data,string message)
        { 
            Success = success;
            Data = data;
            Message = message;
        }
    }
}
