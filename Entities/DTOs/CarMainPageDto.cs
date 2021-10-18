using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarMainPageDto:CarDetailDto,IDto
    {
        public string ImagePath { get; set; }
    }
}
