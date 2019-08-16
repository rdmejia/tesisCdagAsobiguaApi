﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Persistence.Contexts;

namespace tesisCdagAsobiguaApi.Persistence.Repositories
{
    public class ShotRepository : BaseRepository, IShotRepository
    {
        public ShotRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Shot shot)
        {
            await context.Shots.AddAsync(shot);
        }

        public Task<IEnumerable<Shot>> Find(long trainerId, long playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shot>> Find(string trainerUsername, string playerUsername)
        {
            var shots = context.Shots
                                .Include(p => p.Trainer)
                                .Include(p => p.Player)
                                .Include(p => p.XyzShots)
                                .AsNoTracking();

            return await shots.Where(shot => shot.Trainer.Username == trainerUsername && shot.Player.Username == playerUsername)
                               .ToListAsync();
        }

        public async Task<Shot> FindById(long id)
        {
            var shots = context.Shots
                                .Include(p => p.Trainer)
                                .Include(p => p.Player)
                                .Include(p => p.XyzShots)
                                .AsNoTracking();

            var result = await shots.Where(shot => shot.Id == id).SingleOrDefaultAsync();
            return result;
        }

        public Task<IEnumerable<Shot>> FindByPlayerId(long playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shot>> FindByPlayerUsernameAsync(string playerUsername)
        {
            var shots = context.Shots
                                .Include(p => p.Trainer)
                                .Include(p => p.Player)
                                .AsNoTracking();

            return await shots.Where(shot => playerUsername.Equals(shot.Player.Username, StringComparison.OrdinalIgnoreCase))
                                .OrderByDescending(shot => shot.TimeStamp)
                                .ToListAsync();
        }

        public Task<IEnumerable<Shot>> FindByTrainerId(long trainerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shot>> FindByTrainerUsername(string trainerUsername)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shot>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shot>> FindLatestShots(string playerUsername, int count, DateTime fromDate, DateTime toDate)
        {
            // count <= 0 -> all shots
            var shots = context.Shots.AsNoTracking();
            if(count < 1)
            {
                return await shots
                    .Where(shot => playerUsername.Equals(shot.Player.Username, StringComparison.OrdinalIgnoreCase)
                        && DateTime.Compare(fromDate, shot.TimeStamp) <= 0
                        && DateTime.Compare(toDate, shot.TimeStamp) >= 0)
                    .OrderByDescending(shot => shot.TimeStamp)
                    .ToListAsync();
            }

            return await shots
                .Where(shot => playerUsername.Equals(shot.Player.Username, StringComparison.OrdinalIgnoreCase)
                        && DateTime.Compare(fromDate, shot.TimeStamp) <= 0
                        && DateTime.Compare(toDate, shot.TimeStamp) >= 0)
                .OrderByDescending(shot => shot.TimeStamp)
                .Take(count)
                .ToListAsync();
        }
    }
}
