using System.Collections.Generic;
using System.Linq;
using InteractiveVoiceResponseSystem.Areas.Instructor.Models.NewVersionHintsDB;

namespace InteractiveVoiceResponseSystem.Services
{
    public class ExerciseTree
    {      
        public static IList<QuestionGroupTree> BuildQuestionTree(NewVersionHintsDBContext dbContext, string topParent)
        {
            var list = dbContext.QuestionGroupTree.Where(qgt => qgt.CNodeType == topParent).ToList();

            return FlatToHierarchy(list, topParent, "");
        }
        
        private static IList<QuestionGroupTree> FlatToHierarchy(IEnumerable<QuestionGroupTree> list, string parentId, string parentIndex)
        {
            var prefix = string.IsNullOrWhiteSpace(parentIndex) ? "" : parentIndex+".";
            
            return list.Where(i => i.CParentId == parentId)
                .Select((v, i) => new QuestionGroupTree {
                    CNodeId = v.CNodeId, 
                    CParentId = v.CParentId,
                    CNodeName = v.CNodeName,
                    Children = FlatToHierarchy(list, v.CNodeId, prefix + (i + 1)),
                    NodeIndex = prefix + (i + 1)
                }).ToList();
        }
    }
}