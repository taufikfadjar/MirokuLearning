using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.EF.Repository
{
    public interface IInstructionInOutRepository : IRepository<InstructionInOut>
    {

    }

    public class InstructionInOutRepository : RepositoryBase<InstructionInOut>, IInstructionInOutRepository
    {
        public InstructionInOutRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
