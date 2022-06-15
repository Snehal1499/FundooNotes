using DataBaseLayer.Notes;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface INoteBL
    {
        Task AddNote(int UserId, NotePostModel notePostModel);

        Task ChangeColour(int UserId, int NoteId, string Color);

        Task UpdateNote(int UserId, int NoteId, UpdateModel updateModel);

        Task<Note> GetNote(int UserId, int NoteId);
        Task PinNote(int UserId, int NoteId);
    }
}