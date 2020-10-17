using AutoMapper;
using RzrSite.DAL.Exceptions;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Entities;
using RzrSite.Models.Entities.Interfaces;
using RzrSite.Models.Resources.DbFile.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RzrSite.DAL.Repositories
{
    public class DbFileRepo : IDbFileRepo
    {
        private readonly RzrSiteDbContext _ctx;
        private readonly IMapper _mapper;

        public DbFileRepo(RzrSiteDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<IStrippedDbFile> GetAll()
        {
            var files = _ctx.Files.ToList();

            return _mapper.Map<IEnumerable<IStrippedDbFile>>(files);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IStrippedDbFile Get(int id)
        {
            if (!_ctx.Files.Any(c => c.Id.Equals(id)))
                throw new EntityNotFoundException($"File :{id}: not found");
            var file = _ctx.Files.Find(id);

            return _mapper.Map<IStrippedDbFile>(file);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDbFile Get(string path)
        {
            if (path == null) return null;
            if (!_ctx.Files.Any(p => p.Path.ToLower() == path.ToLower()))
                throw new EntityNotFoundException($"File :{path}: not found");
            var file = _ctx.Files.First(f => path.ToLower() == f.Path.ToLower());

            return file;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public int? Add(IPostDbFile file)
        {
            var model = _mapper.Map<DbFile>(file);
            var result = _ctx.Files.Add(model);
            _ctx.SaveChanges();
            return result.Entity?.Id;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IStrippedDbFile Update(int id, IPutDbFile fileChanges)
        {
            if (!_ctx.Files.Any(c => c.Id.Equals(id)))
                throw new EntityNotFoundException($"File :{id}: not found");
            var file = _ctx.Files.Find(id);
            file = _mapper.Map(fileChanges, file);

            _ctx.SaveChanges();

            return _mapper.Map<IStrippedDbFile>(file);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Delete(int id)
        {
            if (!_ctx.Files.Any(c => c.Id.Equals(id)))
                throw new EntityNotFoundException($"File :{id}: not found");

            var file = _ctx.Files.Find(id);

            _ctx.Files.Remove(file);
            _ctx.SaveChanges();

            return true;
        }
    }
}
