using DataBaseLayer.Notes;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRL
    {
        Task AddNote(int UserId, NotePostModel notePostModel);
        Task ChangeColour(int UserId, int NoteId, string Colour);
        Task UpdateNote(int UserId, int NoteId, UpdateModel updateModel);
        Task<Note> GetNote(int UserId, int NoteId);
        Task PinNote(int UserId, int NoteId);

    }
}