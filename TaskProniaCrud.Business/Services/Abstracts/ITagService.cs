using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Core.Models;

namespace TaskProniaCrud.Business.Services.Abstracts
{
    public interface ITagService
    {
         Task AddTagAsync(Tag tag);
        void DeleteTag(int id);
        void UpdateTag(int id, Tag newtag);
        Tag GetTag(Func<Tag,bool>?predicate=null);
        List<Tag> GetAllTags(Func<Tag,bool>?predicate=null);
    }
}
