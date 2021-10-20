using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public int DisplacementId { get; set; }
        public int EngineDisplacement { get; set; }
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public int MinFindexPoint { get; set; }
    }
}
