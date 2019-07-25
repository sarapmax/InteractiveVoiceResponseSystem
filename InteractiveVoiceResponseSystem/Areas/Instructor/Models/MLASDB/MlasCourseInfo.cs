using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.MLASDB
{
    public partial class MlasCourseInfo
    {
        public string CCourseId { get; set; }
        public string CCourseName { get; set; }
        public string CCourseViewMode { get; set; }
        public string CCourseDescription { get; set; }
        public string CCourseDivision { get; set; }
        public string CCourseType { get; set; }
        public string CCourseSubDivision { get; set; }
        public string CCourseBelongUnitId { get; set; }
        public string CCourseBelongUnitName { get; set; }

        public IQueryable<Ivrsprofession> Professions;
    }
}
