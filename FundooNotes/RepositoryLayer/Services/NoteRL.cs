using DataBaseLayer.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        FundooContext fundoocontext;
        IConfiguration configuration;
        public NoteRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundoocontext = fundooContext;
            this.configuration = configuration;
        }
        public async Task AddNote(int UserID, NotePostModel notePostModel)
        {
            try
            {
                Note note = new Note();
                note.UserId = UserID;
                note.Title = notePostModel.Title;
                note.Description = notePostModel.Description;
                note.Colour = notePostModel.Colour;
                note.Ispin = false;
                note.IsArchieve = false;
                note.IsRemainder = false;
                note.CreatedDate = DateTime.Now;
                note.ModifiedDate = DateTime.Now;
                fundoocontext.Add(note);
                await fundoocontext.SaveChangesAsync();


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
                var note = fundoocontext.Note.FirstOrDefault(u => u.UserId == UserId && u.NoteId == NoteId);
                if (note != null)
                {
                    note.Colour = Colour;
                    await fundoocontext.SaveChangesAsync();

                }
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
                var note = fundoocontext.Note.FirstOrDefault(u => u.NoteId == NoteId && u.UserId == UserId);
                if (note != null)
                {
                    note.Title = updateModel.Title;
                    note.Description = updateModel.Description;
                    note.Colour = updateModel.Colour;
                    note.IsArchieve = updateModel.IsArchieve;
                    note.Ispin = updateModel.Ispin;
                    note.IsTrash = updateModel.IsTrash;
                    await fundoocontext.SaveChangesAsync();
                }



            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}