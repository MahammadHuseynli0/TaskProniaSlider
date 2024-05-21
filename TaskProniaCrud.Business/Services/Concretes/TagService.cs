using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProniaCrud.Business.Exceptions;
using TaskProniaCrud.Business.Services.Abstracts;
using TaskProniaCrud.Core.Models;
using TaskProniaCrud.Core.RepositoryAbstarcts;

namespace TaskProniaCrud.Business.Services.Concretes
{
    public class TagService : ITagService
    {
        ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task AddTagAsync(Tag tag)
        {
            if(!_tagRepository.GetAll().Any(x=> x.Name== tag.Name))
            {
                await _tagRepository.AddAsync(tag);
                await _tagRepository.CommitAsync();
            }
            else
            {
                throw new DuplicateException("Bu adli tag movcuddur");
            }
          
        }

        public void DeleteTag(int id)
        {
            Tag exsittag = _tagRepository.Get(x => x.Id == id);
            if (exsittag == null) { throw new DuplicateException("Silinecek bele tag yoxdur"); }
            _tagRepository.Delete(exsittag);
            _tagRepository.Commit();
        }

        public List<Tag> GetAllTags(Func<Tag, bool>? predicate = null)
        {
            return _tagRepository.GetAll(predicate);
        }

        public Tag GetTag(Func<Tag, bool>? predicate = null)
        {
            return _tagRepository.Get(predicate);
        }

        public void UpdateTag(int id, Tag newtag)
        {
            Tag tag= _tagRepository.Get(x=>x.Id == id);
            if (tag == null) { throw new DuplicateException("Bele tag mocud deyil"); }

            if (!_tagRepository.GetAll().Any(x => x.Name == tag.Name && tag.Id != x.Id))
            {
                tag.Name = newtag.Name;
            }
            _tagRepository.Commit();
        }
    }
}
