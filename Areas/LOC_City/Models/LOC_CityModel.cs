﻿using System.ComponentModel.DataAnnotations;

namespace Validation_UI.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }
        [Required]
        public string? CityName { get; set; }
        [Required]
        public string? CityCode { get; set; }
        [Required]
        public int? StateID { get; set; }
        [Required]
        public int? CountryID { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class LOC_CityDropDownModel
    {
        public int CityID { get; set; }
        public string? CityName { get; set; }
    }

    public class LOC_CityFilterModel
    {
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public string? CityName { get; set; }
        public string? CityCode { get; set; }
    }
}
