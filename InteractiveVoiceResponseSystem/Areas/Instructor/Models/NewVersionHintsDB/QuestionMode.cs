﻿using System;
using System.Collections.Generic;

namespace InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB
{
    public partial class QuestionMode
    {
        public string CQid { get; set; }
        public string CPaperId { get; set; }
        public string CDivisionId { get; set; }
        public string CQuestionGroupId { get; set; }
        public string CQuestionGroupName { get; set; }
        public string CQuestionMode { get; set; }
        public string CQuestionType { get; set; }
        public string SimilarId { get; set; }
    }
}
