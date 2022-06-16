using BussinessLayer.Interface;
using DataBaseLayer.Notes;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }
        public async Task AddNote(int UserId, NotePostModel notePostModel)
        {
            try
            {
                await noteRL.AddNote(UserId, notePostModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task ChangeColour(int UserId, int NoteId, string Colour)
        {
            try
            {
                await noteRL.ChangeColour(NoteId, UserId, Colour);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateNote(int UserId, int NoteId, UpdateModel updateModel)
        {
            try
            {
                await noteRL.UpdateNote(NoteId, UserId, updateModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<Note> GetNote(int UserId, int NoteId)
        {
            try
            {
                return this.noteRL.GetNote(UserId, NoteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task PinNote(int UserId, int NoteId)
        {
            try
            {
                await noteRL.PinNote(NoteId, UserId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task ArchiveNote(int UserId, int NoteId)
        {
            try
            {
                await noteRL.ArchiveNote(NoteId, UserId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task TrashNote(int UserId, int NoteId)
        {
            try
            {
                await noteRL.TrashNote(UserId, NoteId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task Reminder(int UserId, int NoteId, DateTimeModel dateTimeModel)
        {
            try
            {
                await noteRL.Reminder(NoteId, UserId, dateTimeModel);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}