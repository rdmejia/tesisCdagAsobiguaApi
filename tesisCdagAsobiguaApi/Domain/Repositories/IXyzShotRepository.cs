using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Domain.Repositories
{
    public interface IXyzShotRepository
    {
        Task<IEnumerable<XyzShot>> FindByShotId(long shotId);
        Task AddAsync(XyzShot xyzShot);
    }
}
